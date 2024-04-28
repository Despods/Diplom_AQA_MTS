using Diplom_AQA_MTS.Models;
using NUnit.Engine.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Diplom_AQA_MTS.Services
{
    public interface IProjectService
    {
        Task<Project> GetProject(int projectId);
        Task<Project> AddProject(Project project);
        HttpStatusCode DeleteProject(int projectId);
    }
}
