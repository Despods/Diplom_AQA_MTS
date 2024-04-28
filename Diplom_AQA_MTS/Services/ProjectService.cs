using Diplom_AQA_MTS.Clients;
using Diplom_AQA_MTS.Models;
using RestSharp;
using System.Net;

namespace Diplom_AQA_MTS.Services
{
    public class ProjectService : IProjectService, IDisposable
    {
        private readonly RestClientExtended _client;

        public ProjectService(RestClientExtended client)
        {
            _client = client;
        }

        public Task<Project> GetProject(int projectId)
        {
            var request = new RestRequest("api/v1/project/{project_id}")
                .AddUrlSegment("project_id", projectId);

            return _client.ExecuteAsync<Project>(request);
        }

        public Task<Project> AddProject(Project project)
        {
            var request = new RestRequest("api/v1/project", Method.Post)
                .AddJsonBody(project);

            return _client.ExecuteAsync<Project>(request);
        }

        public HttpStatusCode DeleteProject(int projectId)
        {
            var request = new RestRequest("api/v1/project/{project_id}", Method.Delete)
                .AddUrlSegment("project_id", projectId)
                .AddJsonBody("{}");

            return _client.ExecuteAsync(request).Result.StatusCode;
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
