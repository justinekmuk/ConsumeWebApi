using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using Moq;
using NUnit.Framework;
using PairingTest.Unit.Tests.Web.Stubs;
using PairingTest.Web.Controllers;
using PairingTest.Web.Models;
using PairingTest.Web.Services;
using QuestionServiceWebApi;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        [Test]
        public async void IndexActionIsReturningQuestions()
        {

            var questionnaire = new Questionnaire
            {
                QuestionnaireTitle = "Geography Questions",
                QuestionsText = new List<string>
                                           {
                                               "What is the capital of Cuba?",
                                               "What is the capital of France?",
                                               "What is the capital of Poland?",
                                               "What is the capital of Germany?"
                                           }
            };
            var response = new HttpResponseMessage()
            {
                Content = new ObjectContent<Questionnaire>(questionnaire, new JsonMediaTypeFormatter())
            };

            var config = new Mock<IConfiguration>();
            config.Setup(c => c.GetAppSetting("QuestionnaireServiceUri")).Returns("http://google.com");
            var handler = new FakeResponseHandler();
            handler.AddFakeResponse(new Uri(config.Object.GetAppSetting("QuestionnaireServiceUri")), TestResponseMessage.QuestionnaireResponse());
            var client = new HttpClient(handler);
            var service = new QuestionnaireService(client, config.Object);
            var controller = new QuestionnaireController(service);


            var action = await controller.Index();
            var result = (QuestionnaireViewModel)action.ViewData.Model;

            Assert.AreEqual("Geography Questions", result.QuestionnaireTitle);
            Assert.AreEqual(4, result.QuestionsText.Count);
        }
    }
}