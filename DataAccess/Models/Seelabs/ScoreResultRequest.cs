using SealabAPI.Base;
using SealabAPI.DataAccess.Entities;

namespace SealabAPI.DataAccess.Models
{
    public class ScoreResultRequest : ScoreListRequest
    {
        public int Group { get; set; }
    }
}
