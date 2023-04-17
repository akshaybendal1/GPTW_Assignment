using BusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json.Linq;

namespace GPTW_Assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        public ILogic _logic;
        public HomeController(ILogic logic)
        {
            _logic = logic;
        }
        [HttpGet]
        public List<QuestionData> Index()
        {
            return _logic.GetData();
        }
    }
}
