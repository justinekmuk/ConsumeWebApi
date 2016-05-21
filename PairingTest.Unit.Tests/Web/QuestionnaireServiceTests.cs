using System.Net;
using NUnit.Framework;
using QuestionServiceWebApi;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using PairingTest.Unit.Tests.Web.Stubs;
using PairingTest.Web.Services;
using Moq;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireServiceTests
    {

        [Test]
        public void GetQuestionnaireAsycIsGettingQuestionTitleAndAllQuestions()
        {
           
            var config = new Mock<IConfiguration>();
            config.Setup(c => c.GetAppSetting("QuestionnaireServiceUri")).Returns("http://google.com");
            var response = TestResponseMessage.QuestionnaireResponse();
            

            var handler = new FakeResponseHandler();
            handler.AddFakeResponse(new Uri(config.Object.GetAppSetting("QuestionnaireServiceUri")), response);
            var client = new HttpClient(handler);
            var service = new QuestionnaireService(client,config.Object);
            var model = service.GetQuestionnaireAsyc();

            Assert.AreEqual("Geography Questions", model.Result.QuestionnaireTitle);
            Assert.AreEqual(4, model.Result.QuestionsText.Count());
            Assert.AreEqual("What is the capital of Cuba?", model.Result.QuestionsText[0]);
            Assert.AreEqual("What is the capital of Germany?", model.Result.QuestionsText[3]);
        }

        [Test]
        public async void InvalidUrlIsGettingStatusCodeNotFound()
        {

            var handler = new FakeResponseHandler();
            handler.AddFakeResponse(new Uri("http://google.com/validurl"), new HttpResponseMessage(HttpStatusCode.OK));
            var client = new HttpClient(handler);

            var response = await client.GetAsync("http://google.com/invalidurl");
            var statusCode = response.StatusCode;

            Assert.AreEqual(HttpStatusCode.NotFound, statusCode);
        }

    }
}
