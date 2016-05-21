using System.Threading.Tasks;
using System.Web.Mvc;
using PairingTest.Web.Models;
using PairingTest.Web.Services;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        private IQuestionnaireService _questionnaireService;
        public QuestionnaireController(IQuestionnaireService questionnaireService)
        {
            _questionnaireService = questionnaireService;
        }

        public QuestionnaireController()
            : this(new QuestionnaireService())
        {
        }



        /* ASYNC ACTION METHOD... IF REQUIRED... */
        public async Task<ViewResult> Index()
        {
            var model = await _questionnaireService.GetQuestionnaireAsyc();
            return View(model);
        }


        //public ViewResult Index()
        //{
        //    return View(new QuestionnaireViewModel());
        //}
    }
}
