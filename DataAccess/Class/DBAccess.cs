using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Interface;
using Models;
using Newtonsoft.Json.Linq;

namespace DataAccess.Class
{
    public class DBAccess : IDBAccess
    {
        public async Task<List<QuestionData>> GetData()
        {
            try
            {
                List<QuestionData> data = new List<QuestionData>();

                var paramsObj = new DynamicParameters();
                using (SqlConnection con = new SqlConnection(@"Data Source=Akshay-PC\SQLEXPRESS;Initial Catalog=GPTW;Integrated Security=True"))
                {
                    var data2 = await con.QueryAsync<QuestionData>("sp_get_Rawdata", commandType: System.Data.CommandType.StoredProcedure);
                    data = data2.ToList();
                }
                return data;
            }
            catch (Exception ex)
            {
                //Error Log
                throw ex;
            }
        }
    }
}
