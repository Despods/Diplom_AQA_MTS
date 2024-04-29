using Diplom_AQA_MTS.Models;
using NLog;
using NUnit.Allure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Diplom_AQA_MTS.Tests.API
{
    public class ApiTests : BaseApiTest
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private Project _project;

        //[Test]
        public void CreateProjectApiTest()
        {
            _project = new Project
            {
                ProjectName = $"TestCats {DateTime.Now}",
                Description = "CatsTesting"
            };

            var actualProject = ProjectService!.AddProject(_project);

            Assert.That(actualProject.Result.ProjectName, Is.EqualTo(_project.ProjectName));

            _project = actualProject.Result;
        }
    }
}
