using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PairingTest.Web.Models;
using System.Net.Http;

namespace PairingTest.Web.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private HttpClient _client;
        private IConfiguration _configuration;
        public QuestionnaireService(HttpClient client,IConfiguration configuartion)
        {
            _client = client;
            _configuration = configuartion;
        }

        public QuestionnaireService()
            : this(new HttpClient(), new Configuration())
        {
        }

        public async Task<QuestionnaireViewModel> GetQuestionnaireAsyc()
        {
            var viewModel = new QuestionnaireViewModel();
            var questionnaireServiceUrl = _configuration.GetAppSetting("QuestionnaireServiceUri");

             
            var response = await _client.GetAsync(questionnaireServiceUrl);
            if (response.IsSuccessStatusCode)
            {
                viewModel = await response.Content.ReadAsAsync<QuestionnaireViewModel>();
            }
            response.EnsureSuccessStatusCode();

            return viewModel;
        }
        
    }
}