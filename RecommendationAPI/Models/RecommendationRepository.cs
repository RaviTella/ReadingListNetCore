using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationDotNetCore.Models
{
    public class RecommendationRepository : IRecommendationRepository, IDisposable
    {

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recommendation> GetRecommendations()
        {
            List<Recommendation> recommendations = new List<Recommendation>();
            recommendations.Add(new Recommendation("1", "01234", "Getting Started with kubernetes", "Jonathan Baier", "Learn Kubernetes the right way", "/images/Kubernetes.jpg"));
            recommendations.Add(new Recommendation("2", "95201", "Learning Docker Networking", "Rajdeep Das", "Docker networking deep dive", "/images/DockerNetworking.jpg"));
            recommendations.Add(new Recommendation("6", "95298", "Spring Microservices", "Rajesh RV", "Build scalable microservices with Spring and Docker", "/images/SpringMicroServices.jpg"));
            recommendations.Add(new Recommendation("5", "01264", "Learning Concurrent Programming in Scala", "Aleksandar Prokopec", "Learn the art of building concurrent applications", "/images/Scala.jpg"));
            recommendations.Add(new Recommendation("3", "23123", "Modern Authentication with AzureAD ", "Vittorio Bertocci", "Azure active directory capabilities", "/images/AzureAD.jpg"));
            recommendations.Add(new Recommendation("4", "11201", "Microsoft Azure SQL", "Leonard G.Lobel", "Setp by step guide for developers", "/images/AzureSQL.jpg"));
            recommendations.Add(new Recommendation("7", "28526", "Developing Azure and Web Services", "Rajdeep Das", "Exam Ref 70-487", "/images/AzureCert.jpg"));
            recommendations.Add(new Recommendation("8", "95298", "Programming Microsoft Azure Service fabric", "Haishi Bai", "Service fabric for developers", "/images/ServiceFabric.jpg"));
            return recommendations;
        }
    }
}
