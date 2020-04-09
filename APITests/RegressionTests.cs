using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp01;

namespace APITests
{
    [TestClass]
    public class RegressionTests
    {
        [TestMethod]
        public void VeryListOfUsers()
        {
            var demo = new Demo();
            var response = demo.GetUsers();

            Assert.AreEqual(2,response.Page);
            Assert.AreEqual("Michael",response.Data[0].First_Name);

        }


        [TestMethod]
        public void CreateNewUser()
        {
            string payload = @"{
                ""name"": ""Mike"",
                ""job"": ""Team leader""
            }";

            var user = new APIHelper<CreateUserDto>();

            var url = user.SetUrl("api/users");

            var request = user.CreatePostRequest(payload);

            var response = user.GetResponse(url, request);

            CreateUserDto content = user.GetContent<CreateUserDto>(response);


            Assert.AreEqual("Mike", content.Name);
            Assert.AreEqual("Team leader", content.Job);

        }
    }
}
