using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface;
using DataAccess.Interface;
using Models;
using Newtonsoft.Json.Linq;

namespace BusinessLogic.Class
{
    public class Logic : ILogic
    {
        public IDBAccess _idbAccess ;
        public Logic(IDBAccess iDBAccess)
        {
            _idbAccess = iDBAccess;
        }
        public async Task<List<QuestionData>> GetData()
        {
            List<QuestionData> res = await _idbAccess.GetData();
            return res;
        }
        public async Task<List<QuestionData>> GetData(List<int> QuestionIds)
        {
            List<QuestionData> res = await _idbAccess.GetData(QuestionIds);
            return res;
        }
        public async Task saveData(QuestionData data)
        {
            await _idbAccess.saveData(data);
        }
        public async Task<double> getCountData()
        {
            List<ScoreCount> resData = await _idbAccess.GetCountData();
            int count1=0, count2=0, count3=0, count4 =0, count5 = 0;
            if (resData.Where(x => x.Score == 1).Any())
             count1 = resData.Where(x => x.Score == 1).FirstOrDefault().Count;
            if (resData.Where(x => x.Score == 2).Any())
                count2 = resData.Where(x => x.Score == 2).FirstOrDefault().Count;
            if(resData.Where(x => x.Score == 3).Any())
             count3 = resData.Where(x => x.Score == 3).FirstOrDefault().Count;
            if (resData.Where(x => x.Score == 4).Any())
                count4 = resData.Where(x => x.Score == 4).FirstOrDefault().Count;
            if (resData.Where(x => x.Score == 5).Any())
                count5 = resData.Where(x => x.Score == 5).FirstOrDefault().Count;
            double res2 = Convert.ToDouble((count5 + count4)) / Convert.ToDouble((count5 + count4 + count3 + count2 + count1));
            double res = res2 * 100;
            return res;
        }
    }
}
