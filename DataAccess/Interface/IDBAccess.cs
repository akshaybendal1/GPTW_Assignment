using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json.Linq;

namespace DataAccess.Interface
{
    public interface IDBAccess
    {
        Task<List<QuestionData>> GetData();
        Task saveData(QuestionData data);
        Task<List<ScoreCount>> GetCountData();
        Task<List<QuestionData>> GetData(List<int> QuestionIds);
    }
}
