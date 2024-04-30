using Diplom_AQA_MTS.Clients;
using Diplom_AQA_MTS.Services;
using NLog;
using NUnit.Allure.Core;

namespace Diplom_AQA_MTS.Tests.API
{
    [Parallelizable(scope: ParallelScope.Fixtures)]
    [AllureNUnit]

    public class BaseApiTest
    {
        protected readonly Logger Logger = LogManager.GetCurrentClassLogger();
        protected ProjectService? ProjectService;

        [OneTimeSetUp]
        public void SetUpApi()
        {
            var restClient = new RestClientExtended();
            ProjectService = new ProjectService(restClient);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            ProjectService?.Dispose();
        }
    }
}
