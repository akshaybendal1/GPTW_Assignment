using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json.Linq;

namespace BusinessLogic.Interface
{
    public interface ILogic
    {
        List<QuestionData> GetData();
    }
}
