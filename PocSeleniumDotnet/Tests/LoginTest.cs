using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PocSeleniumDotnet
{
    [TestClass]
    [TestCategory("Login feature")]
    public class LoginTest : BaseTest
    {
        Credentials credentials = new Credentials();
        HomePage homePage;

        [TestMethod]
        [Description("Checks if profile is loaded after login with valid credentials")]
        public void LoginWithValidCredentialsTest()
        {
            credentials.FullName = "test";
            credentials.Password = "12345";

            homePage = new HomePage(Driver);
            homePage.GoTo();
            var profile = homePage.Login.FillValidCredentialsAndClick(credentials);
            
            Assert.IsTrue(profile.IsLoaded);
        }

        [TestMethod]
        [Description("Checks if full name required message is displayed")]
        public void LoginWithoutFullNameTest()
        {
            credentials.FullName = "";
            credentials.Password = "12345";

            homePage = new HomePage(Driver);
            homePage.GoTo();
            var login = homePage.Login.FillCredentialsWithoutRequiredFieldAndClick(credentials);
            var expectedErrorMsg = "Please provide your full name";

            Assert.AreEqual(login.ErrorMsgText, expectedErrorMsg,
                $"Expected error msg {expectedErrorMsg}, " + 
                $"Actual error msg {login.ErrorMsgText}");
        }

    }
}
