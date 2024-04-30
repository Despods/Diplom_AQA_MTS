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

        /// <summary>
        /// Данный метод используется для создания проекта через АПИ.
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public Task<CreateProjectResponse> AddProject(ProjectQase project)
        {
            var request = new RestRequest("v1/project", Method.Post)
                .AddJsonBody(project);

            return _client.ExecuteAsync<CreateProjectResponse>(request);
        }

        /// <summary>
        /// Данный метод ползволяет получить информацию о проекта используя код проекта.
        /// </summary>
        /// <param name="projectCode">project code</param>
        /// <returns></returns>
        public Task<GetProjectResponse> GetProject(string projectCode)
        {
            var request = new RestRequest("v1/project/{code}", Method.Get)
                .AddUrlSegment("code", projectCode);

            return _client.ExecuteAsync<GetProjectResponse>(request);
        }

        /// <summary>
        /// Данный метод вернет все проекты, которые есть на аккаунте.
        /// </summary>
        /// <returns></returns>
        public Task<GetAllProjectsResponse> GetAllProjects()
        {
            var request = new RestRequest("v1/project", Method.Get);

            return _client.ExecuteAsync<GetAllProjectsResponse>(request);
        }

        /// <summary>
        /// Данный метод позволяет удалить проект используя код проекта.
        /// </summary>
        /// <param name="projectCode">project code</param>
        /// <returns></returns>
        public HttpStatusCode DeleteProject(string projectCode)
        {
            var request = new RestRequest("v1/project/{code}", Method.Delete)
                .AddUrlSegment("code", projectCode);

            return _client.ExecuteAsync(request).Result.StatusCode;
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}