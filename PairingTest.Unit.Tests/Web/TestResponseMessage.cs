using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using QuestionServiceWebApi;

namespace PairingTest.Unit.Tests.Web
{
    public class TestResponseMessage
    {

        public static HttpResponseMessage QuestionnaireResponse()
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
            return response;
        }
    }
}
