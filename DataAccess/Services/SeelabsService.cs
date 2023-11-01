﻿using AngleSharp.Common;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using SealabAPI.DataAccess.Entities;
using SealabAPI.DataAccess.Extensions;
using SealabAPI.DataAccess.Models;
using SealabAPI.Helpers;
using System.Dynamic;
using System.Net;

namespace SealabAPI.DataAccess.Services
{
    public class SeelabsService
    {
        private readonly HttpRequestHelper _client;
        private readonly HttpRequest _httpRequest;
        private readonly int _idLab;
        private string _token => _httpRequest.ReadToken("seelabs_token");
        public SeelabsService(IHttpContextAccessor httpRequest, IConfiguration configuration)
        {
            _httpRequest = httpRequest.HttpContext.Request;
            _client = new HttpRequestHelper(configuration["SeelabsUrl"]);
            _idLab = int.Parse(configuration["LabId"]);
        }
        public async Task<List<SeelabsBAPResponse>> BAP(SeelabsBAPRequest request)
        {
            SetToken();
            HttpResponseMessage response = await _client.HtmlPost("/pageasisten/bap", request);
            var responseHtml = await response.ParseHtml();
            var tr = responseHtml.QuerySelector("table")?.QuerySelectorAll("tr").Skip(1);
            if (tr.ElementAt(0).Children.Length > 1)
            {
                return tr.Select(td => new SeelabsBAPResponse(td)).ToList();
            }
            return null;
        }
        public async Task<List<SeelabsScoreStudentResponse>> ScoreStudent()
        {
            SetToken();
            HttpResponseMessage response = await _client.HtmlPost("/page/nilai_user", new SeelabsScoreStudentRequest());
            var responseHtml = await response.ParseHtml();
            return responseHtml.QuerySelector("table")?.QuerySelectorAll("tr").Skip(1).Select(td => new SeelabsScoreStudentResponse(td)).ToList();
        }
        public async Task<List<SeelabsListGroupResponse>> ScoreList(SeelabsScoreListRequest request)
        {
            SetToken();
            HttpResponseMessage response = await _client.HtmlPost("/pageasisten/lihat_inputnilai", request);
            var responseHtml = await response.ParseHtml();
            var table = responseHtml.QuerySelector("table");
            var result = TableToJson(table, 6);
            return result.Select(group => new SeelabsListGroupResponse(group)).ToList();
        }
        public async Task<SeelabsScoreResultResponse> ScoreResult(SeelabsScoreResultRequest request)
        {
            SetToken();
            HttpResponseMessage response = await _client.HtmlPost("/pageasisten/lihat_inputnilai", request);
            var responseHtml = await response.ParseHtml();
            var tr = responseHtml.QuerySelector("table")?.QuerySelectorAll("tr")?.Skip(2);
            return new SeelabsScoreResultResponse(tr);
        }
        public async Task<SeelabsScoreDetailResponse> ScoreDetail(SeelabsScoreDetailRequest request)
        {
            SetToken();
            HttpResponseMessage response = await _client.HtmlPost("/pageasisten/lihat_inputnilai", request);
            var responseHtml = await response.ParseHtml();
            var tr = responseHtml.QuerySelector("table")?.QuerySelectorAll("tr")?.Skip(2);
            var module = int.Parse((responseHtml.QuerySelector("select[name='modulid']") as IHtmlSelectElement).Value);
            var group = int.Parse((responseHtml.QuerySelector("input[name='kelompok_id']") as IHtmlSelectElement).Value);
            return new SeelabsScoreDetailResponse(module, group, tr);
        }
        public async Task<string> ScoreDelete(SeelabsScoreDeleteRequest request)
        {
            SetToken();
            HttpResponseMessage response = await _client.HtmlPost("/pageasisten/lihat_inputnilai", request);
            var responseHtml = await response.ParseHtml();
            var result = responseHtml.QuerySelector("#myAlert b")?.TextContent;
            if (result == "Gagal")
                throw new ArgumentException("Failed delete score!");
            return result;
        }
        public async Task<string> ScoreUpdate(ScoreUpdateRequest data)
        {
            SetToken();
            SeelabsScoreUpdateRequest update = new(data);
            var request = update.ToDictionary().ToList();
            data.GetScores(request);
            HttpResponseMessage response = await _client.HtmlPost("/pageasisten/lihat_inputnilai", request);
            var responseHtml = await response.ParseHtml();
            var result = responseHtml.QuerySelector("#myAlert b")?.TextContent;
            if (result == "Gagal")
                throw new ArgumentException("Failed update score!");
            return result;
        }
        public async Task<List<SeelabsListGroupResponse>> GroupList(SeelabsListGroupRequest request)
        {
            SetToken();
            HttpResponseMessage response = await _client.HtmlPost("/pageasisten/inputnilaipraktikum", request);
            var responseHtml = await response.ParseHtml();
            var table = responseHtml.QuerySelector("table");
            var result = TableToJson(table, 4);
            return result.Select(group => new SeelabsListGroupResponse(group)).ToList();
        }
        public async Task<List<SeelabsDetailGroupResponse>> GroupDetail(SeelabsDetailGroupRequest request)
        {
            SetToken();
            HttpResponseMessage response = await _client.HtmlPost("/pageasisten/inputnilaipraktikum", request);
            var responseHtml = await response.ParseHtml();
            var table = responseHtml.QuerySelector("table");
            return table?.QuerySelectorAll("tr").Skip(2).Select(td => new SeelabsDetailGroupResponse(td)).ToList();
        }
        public async Task<string> ScoreInput(ScoreInputRequest data)
        {
            SetToken();
            SeelabsScoreInputRequest input = new(data);
            var request = input.ToDictionary().ToList();
            data.GetScores(request);
            HttpResponseMessage response = await _client.HtmlPost("/pageasisten/inputnilaipraktikum", request);
            var responseHtml = await response.ParseHtml();
            var result = responseHtml.QuerySelector("#myAlert b")?.TextContent;
            if (result == "Gagal")
                throw new ArgumentException("Failed input score!");
            return result;
        }
        public async Task<List<SeelabsScheduleResponse>> Schedule()
        {
            SetToken();
            HttpResponseMessage response = await _client.HtmlGet("/pageasisten/datajadwal");
            var responseHtml = await response.ParseHtml();
            return responseHtml.QuerySelector("table")?.QuerySelectorAll("tr").Skip(1).Select(td => new SeelabsScheduleResponse(td)).ToList();
        }
        public async Task<SeelabsLoginResponse> Login(SeelabsLoginRequest data)
        {
            HttpResponseMessage response = await _client.HtmlPost("/home/loginprak", data);
            var responseHtml = await response.ParseHtml();
            var name = responseHtml.QuerySelector(".navbar-link")?.TextContent;
            Cookie cookie = name != null ? _client.GetCookie("ci_session") : null;
            return new SeelabsLoginResponse(name, cookie);
        }
        private static List<dynamic> TableToJson(IElement table, int rowCount)
        {
            int count = 0, id_group = 0, counter = 0;
            string span;
            var columns = table?.QuerySelectorAll("td");
            List<object> result = new();
            List<string> names = new();
            foreach (var item in columns)
            {
                if ((span = item.GetAttribute("rowspan")) != null)
                {
                    count = int.Parse(span);
                    counter++;
                    if (counter == rowCount)
                    {
                        counter = 0;
                        id_group = int.Parse(item.QuerySelector("input[name='kelompok_id']").GetAttribute("value"));
                    }
                }
                else
                {
                    names.Add(item.TextContent);
                    if (names.Count == count)
                    {
                        result.Add(new { id_group, names });
                        names = new();
                    }
                }
            }
            return result;
        }
        private void SetToken()
        {
            _client.AddHeader("Cookie", "ci_session=" + _token);
        }
    }
}
