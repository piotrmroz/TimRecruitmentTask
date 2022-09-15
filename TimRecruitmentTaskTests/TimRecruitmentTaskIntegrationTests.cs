using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TimRecruitmentTaskTests
{
    internal class TimRecruitmentTaskIntegrationTests
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Users\Piotrek\source\repos\TimRecruitmentTask\TimRecruitmentTask\Drivers");
        }

        [Test]
        public void PublicationSearchTest_SampleSearch()
        {
            var length = "100";

            var sampleSearchText = "Cyclosporin dermatology Covid-19";
            driver.Navigate().GoToUrl("https://localhost:7270/Home/Index");

            var textBox = driver.FindElement(By.Id("searchTextbox"));
            textBox.SendKeys(sampleSearchText);

            var submitButton = driver.FindElement(By.ClassName("btn"));
            submitButton.Click();

            var textArea = driver.FindElement(By.ClassName("search-result"));
            var numberOfRecords = (textArea.Text.Split("\n").Length + 1) / 3;

            numberOfRecords.Equals(length);
        }

        [Test]
        public void PublicationSearchTest_IsEmpty()
        {
            var x = "asjchjtftmhg";
            driver.Navigate().GoToUrl("https://localhost:7270/Home/Index");

            var textBox = driver.FindElement(By.Id("searchTextbox"));
            textBox.SendKeys(x);

            var submitButton = driver.FindElement(By.ClassName("btn"));
            submitButton.Click();

            var result = driver.FindElement(By.ClassName("search-result"));

            result.Text.Should().BeEquivalentTo("Brak pasujących publikacji");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
