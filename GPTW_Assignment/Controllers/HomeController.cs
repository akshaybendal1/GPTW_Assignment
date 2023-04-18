using BusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
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
        public async Task<List<QuestionData>> Index()
        {
            return await _logic.GetData();
        }
        [HttpPost]
        [Route("/submitdata")]
        public async Task<ActionResult> Index([FromBody] QuestionData data)
        {
            await _logic.saveData(data);
            return Ok();
        }
        [HttpGet]
        [Route("/getdata")]
        public async Task<string> Getdata()
        {
            var res = await _logic.getCountData();
            JObject obj = new JObject();
            obj.Add("positive_score", res.ToString());
            obj["positive_score"] = res;
            return JsonConvert.SerializeObject( obj);
        }
        [HttpPost]
        [Route("/getdata")]
        public async Task<string> Getdata([FromBody] List<int> QuestionIDs)
        {
           
            var res = await _logic.GetData(QuestionIDs);
            JArray arr = new JArray();

            foreach (var o in res)
            {
                JObject obj = new JObject();
                obj.Add("questionId", o.QuestionID);
                obj.Add("Score", o.Score);
                arr.Add(obj);
            }
            return JsonConvert.SerializeObject(arr);
        }
    }
}
