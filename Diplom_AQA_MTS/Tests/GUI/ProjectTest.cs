using Diplom_AQA_MTS.Pages;
using Diplom_AQA_MTS.Steps;
using Allure.Net.Commons;
using NUnit.Allure.Attributes;
using Diplom_AQA_MTS.Models;
using Diplom_AQA_MTS.Pages.ProjectPages;

namespace Diplom_AQA_MTS.Tests.GUI
{
    [AllureSuite("UI Project Tests")]
    public class ProjectTest : BaseTest
    {
        [Test]
        [AllureFeature("Project")]
        [AllureName("Добавление проекта")]
        public void AddProjectTest()
        {
            Project projectAdd = new()
            {
                ProjectName = $"Cats {Random.Next(101)}",
                ProjectKey = $"Key{Random.Next(101)}",
                Description = "Cat working with me"
            };

            NavigationSteps.SuccessfulLogin(Admin);
            NavigationSteps.NavigateToAddProjectPage()
                .CreateProjectMenuSelect()
                .AddProjectSuccessfull(projectAdd);
            
            AllProjectsPage AllProjectsPage = NavigationSteps.NavigateToAllProjectsPage();
            AllureApi.Step("Проверка что наш проект содержится во всех проектах");
            Assert.That(AllProjectsPage.ProjectNamesText.Contains(projectAdd.ProjectName));
        }

        [Test]
        [AllureFeature("Project")]
        [AllureName("Удаление проекта")]
        public void RemoveProjectTest()
        {
            Project projectDel = new()
            {
                ProjectName = $"Cats {Random.Next(101)}",
                ProjectKey = $"Key{Random.Next(101)}",
                Description = "Cat working with me"
            };

            NavigationSteps.SuccessfulLogin(Admin);
            NavigationSteps.NavigateToAddProjectPage()
                .CreateProjectMenuSelect()
                .AddProjectSuccessfull(projectDel);

            AllProjectsPage AllProjectsPage = NavigationSteps.NavigateToAllProjectsPage();

            var index = AllProjectsPage.ProjectKeys.FindIndex
                (projectKey => projectKey.Text.Trim().ToLower() == projectDel.ProjectKey.ToLower());

            AllProjectsPage
                .SelectRecordByProjectKeyElement(AllProjectsPage.ProjectKeys[index])
                .DeleteButtonClick()
                .ConfirmButtonClick<DashBoardPage>();
            

           AddProjectPage AddProjectPage = NavigationSteps
                 .NavigateToAddProjectPage();
            AddProjectPage.ButtunBasePage.Click();

            AllureApi.Step("Проверяем, чито удаленного проекта нет в списке всех проектов");
            Assert.That(!AddProjectPage.ProjectsMenu.GetOptions().Contains(projectDel.ProjectName));
        }

        [Test]
        [AllureFeature("Project")]
        [AllureName("Негативная проверка граничного значения поля key проекта")]
        public void NegativeKeyInputCheck()
        {
            Project project = new()
            {
                ProjectName = $"Cats {Random.Next(101)}",
                ProjectKey = "123456",
                Description = "Cat working with me}"
            };

            NavigationSteps.SuccessfulLogin(Admin);
            NavigationSteps.NavigateToAddProjectPage()
                .CreateProjectMenuSelect()
                .InputProjectFields(project);
            AddProjectPage AddProjectPage = new AddProjectPage(Driver);
            AllureApi.Step("Проверяем, что кнопка сохранения неактивна и ошибка отображается");
            Assert.Multiple(() =>
            {
                Assert.That(!AddProjectPage.AddButton.Enabled);
                Assert.That(AddProjectPage.ErrorLabel.Displayed);
            });
        }
    }
}