using Diplom_AQA_MTS.Models;
using NLog;
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

        [Test]
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

        [Test]
        [Order(2)]
        [Category("Smoke")]
        public void GetProjectApiTest()
        {
            var getProject = ProjectService!.GetProject(_project.Id);

            Assert.Multiple(() =>
            {
                Assert.That(getProject.Result.ProjectName, Is.EqualTo(_project.ProjectName));
                Assert.That(getProject.Result.Description, Is.EqualTo(_project.Description));
                Assert.That(getProject.Result.Id, Is.EqualTo(_project.Id));
            });
        }

        [Test]
        [Order(3)]
        [Category("Smoke")]
        [Category("Regression")]
        public void SuccessDeleteProject()
        {
            var successDelProject = ProjectService!.DeleteProject(_project.Id);

            Assert.That(successDelProject, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        [Order(4)]
        [Category("Regression")]
        public void InvalidDeleteProject()
        {
            var invalidDeleteProject = ProjectService!.DeleteProject(_project.Id);
            Assert.That(invalidDeleteProject, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}
