﻿using Allure.Core;
using Allure.Net.Commons;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using Diplom_AQA_MTS.Models;
using Diplom_AQA_MTS.Steps;
using Diplom_AQA_MTS.Helpers.Configuration;

namespace Diplom_AQA_MTS.Tests;

[Parallelizable(scope: ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[AllureNUnit]
public class BaseTest
{
    protected IWebDriver Driver { get; private set; }
    protected User? Admin { get; private set; }
    protected NavigationSteps NavigationSteps;
    protected Random Random = new Random();

    [OneTimeSetUp]
    public static void GlobalSetup()
    {
        AllureLifecycle.Instance.CleanupResultDirectory();//перед каждым запуском тестов - чистим прошлый отчет аллюр
    }

    [SetUp]
    public void Setup()
    {
        Driver = new Browser().Driver;

        Admin = new User()//инициализируем пользователя админа, взяв настройки из апсетинга
        {
            Username = Configurator.AppSettings.Username,
            Password = Configurator.AppSettings.Password
        };

        NavigationSteps = new NavigationSteps(Driver);

        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
    }

    [TearDown]
    public void TearDown()
    {
        // Проверка, был ли тест сброшен
        try
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                // Создание скриншота
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                // Прикрепление скриншота к отчету Allure
                AllureLifecycle.Instance.AddAttachment("Screenshot", "image/png", screenshotBytes);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        Driver.Quit();
    }
}