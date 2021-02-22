using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationDotNetCore.Models
{
    public interface IRecommendationRepository : IDisposable
    {
        IEnumerable<Recommendation> GetRecommendations();
    }
}
