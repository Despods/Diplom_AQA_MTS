using Diplom_AQA_MTS.Models;
using RestSharp;
using System.Net;

namespace Diplom_AQA_MTS.Services
{
    public interface IProjectService
    {
        Task<CreateProjectResponse> AddProject(ProjectQase project);
        Task<GetProjectResponse> GetProject(string projectCode);
        Task<GetAllProjectsResponse> GetAllProjects();
        HttpStatusCode DeleteProject(string projectCode);
    }
}
