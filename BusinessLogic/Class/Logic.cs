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
        public List<QuestionData> GetData()
        {
           return  _idbAccess.GetData().Result;
        }
    }
}
