using Allure.Net.Commons;
using Diplom_AQA_MTS.Models;
using Newtonsoft.Json;
using NLog;
using NUnit.Allure.Attributes;
using System.Net;
using System.Reflection;

namespace Diplom_AQA_MTS.Tests.API
{
    [AllureSuite("API Project Tests")]
    public class ApiTests : BaseApiTest
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private ProjectQase _project;
        private ProjectQase _projectBad;
        private CreateProjectResponse _createProjectResponse;
        private GetProjectResponse _getProjectResponse;
        protected Random Random = new Random();

        [Test]
        [AllureName("Добавление проекта")]
        [AllureDescription("Тест на создание проекта")]
        [AllureFeature("NFE")]
        [Order(1)]
        public void CreateProject()
        {
            _project = new ProjectQase
            {
                Title = $"Cats {Random.Next(101)}",
                Description = "Cats help me please",
                Code = "999"
            };
            Logger.Info(_project);
            var actualProject = ProjectService!.AddProject(_project);

            Assert.That(actualProject.Result.Result.Code, Is.EqualTo(_project.Code));
            AllureApi.Step($"Проект успешно создан");
            _createProjectResponse = actualProject.Result;

        }

        [Test]
        [AllureName("Получение проекта по коду")]
        [AllureDescription("Получение данных проекта по коду проекта")]
        [AllureFeature("NFE")]
        [Order(2)]
        public void GetProjectTest()
        {
            var projectGetApi = ProjectService!.GetProject("999");

            AllureApi.Step($"Получены данные по проекту");
            Assert.Multiple(() =>
            {
                Assert.That(projectGetApi.Result?.Result?.Title, Is.EqualTo(_project.Title));
                Assert.That(projectGetApi.Result?.Result?.Code, Is.EqualTo(_project.Code));
            });
        }

        [Test]
        [AllureName("Получение проекта с несуществующим CODE")]
        [AllureDescription("Получение данных проекта по коду несуществующего проекта")]
        [AllureFeature("AFE")]
        public void GetMissingProjectTest()
        {
            var actualProject = ProjectService!.GetProject("579");
            AllureApi.Step($"Получены необходимая ошибка {actualProject.Result.ErrorMessage}");
            Assert.That(actualProject.Result.ErrorMessage, Is.EqualTo("Project not found"));
        }

        [Test]
        [AllureName("Получение всех проектов")]
        [AllureDescription("Получение всех существующих проектов")]
        [AllureFeature("NFE")]
        [Order(3)]
        public void GetAllProjectsTest()
        {
            var allProjectsGetApi = ProjectService!.GetAllProjects();

            var totalProjectCounty = allProjectsGetApi!.Result!.Result.Total;
            AllureApi.Step($"Получены данные о всех проектах");
            Assert.Multiple(() =>
            {
                Assert.That(allProjectsGetApi!.Result.Status, Is.EqualTo(true));
                Assert.That(allProjectsGetApi!.Result.Result!.Total, Is.GreaterThan(0));
            });
        }

        [Test]
        [AllureName("Удаление проекта")]
        [AllureDescription("Удаление проекта по коду проекта")]
        [AllureFeature("NFE")]
        [Order(4)]
        public void DeleteProject()
        {
            var deletingProject = ProjectService!.DeleteProject(_project.Code);

            AllureApi.Step($"Проект удалён");
            Assert.That(deletingProject, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        [AllureName("Создание проекта из JSON")]
        [AllureDescription("Создание проекта из JSON файла")]
        [AllureFeature("NFE")]
        [Order(5)]
        public void GetProjectFromJSON()
        {
            //получаем муть к директории
            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Конструируем путь к файлу внутри проекта
            string projectJson = File.ReadAllText(Path.Combine(assemblyPath!, "Resources", "Project_JSON_data.json"));

            // Создем экземпляр объекта из JSON
            var projectObject = JsonConvert.DeserializeObject<ProjectQase>(projectJson);
            _logger.Debug(projectObject);

            var projectCreateFromJSON = ProjectService!.AddProject(projectObject!);

            AllureApi.Step($"Получены данные по проекту");
            Assert.Multiple(() =>
            {
                Assert.That(projectCreateFromJSON!.Result.Status, Is.EqualTo(true));
                Assert.That(projectCreateFromJSON!.Result.Result!.Code, Is.EqualTo(projectObject!.Code.ToString()));
            });
        }

        [Test]
        [AllureName("Создание проекта проверка поля CODE")]
        [AllureDescription("Проверка, что поле CODE не может быть больше 10 символов")]
        [AllureFeature("AFE")]
        public void BadProjectCode()
        {
            _projectBad = new ProjectQase
            {
                Title = $"Cats {Random.Next(101)}",
                Description = "Cats help me please",
                Code = "12345678910"
            };
            Logger.Info(_projectBad);

            var actualProject = ProjectService!.AddProject(_projectBad);

            AllureApi.Step($"Получена ожидаемая ошибка {actualProject.Result.ErrorFields[0].Error}");
            Assert.Multiple(() =>
            {
                Assert.That(actualProject!.Result.Status, Is.EqualTo(false));
                Assert.That(actualProject.Result.ErrorMessage, Is.EqualTo("Data is invalid."));
                Assert.That(actualProject.Result.ErrorFields[0].Error, Is.EqualTo("Project code may not be greater than 10 characters."));
            });

        }

        [Test]
        [AllureName("Создание проекта проверка поля TITLE")]
        [AllureDescription("Проверка, что поле TITLE должно быть обязательно заполнено")]
        [AllureFeature("AFE")]
        public void RequiredFieldTest()
        {
            _projectBad = new ProjectQase
            {
                Title = null,
                Description = "Cats help me please",
                Code = "12345678910"
            };

            var actualProject = ProjectService!.AddProject(_projectBad);

            AllureApi.Step($"Получена ожидаемая ошибка {actualProject.Result.ErrorFields[0].Error}");
            Assert.Multiple(() =>
            {
                Assert.That(actualProject.Result.Status, Is.EqualTo(false));
                Assert.That(actualProject.Result.ErrorMessage, Is.EqualTo("Data is invalid."));
                Assert.That(actualProject.Result.ErrorFields[0].Error, Is.EqualTo("Title is required."));
            });
        }
    }
}
