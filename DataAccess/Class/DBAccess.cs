using System;
using System.Collections.Generic;
using System.Data;
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
        public async Task<List<QuestionData>> GetData(List<int> QuestionIds)
        {
            try
            {
                List<QuestionData> data = new List<QuestionData>();

                DataTable dt = new DataTable();
                dt.Columns.Add("questionId");
                foreach (var ques in QuestionIds)
                {
                    dt.Rows.Add(ques);
                }
                var paramsObj = new DynamicParameters();
                paramsObj.Add("@QuestionIDs", dt.AsTableValuedParameter("QuestionIds"));
                using (SqlConnection con = new SqlConnection(@"Data Source=Akshay-PC\SQLEXPRESS;Initial Catalog=GPTW;Integrated Security=True"))
                {
                    var data2 = await con.QueryAsync<QuestionData>("Sp_get_rawdatabyQuestionID",param: paramsObj, commandType: System.Data.CommandType.StoredProcedure);
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
        public async Task saveData(QuestionData data)
        {
            try
            {
                var paramsObj = new DynamicParameters();
                paramsObj.Add("@questionid", data.QuestionID);
                paramsObj.Add("@questiontext", data.QuestionText);
                paramsObj.Add("@score", data.Score);
                using (SqlConnection con = new SqlConnection(@"Data Source=Akshay-PC\SQLEXPRESS;Initial Catalog=GPTW;Integrated Security=True"))
                {
                    var res = await con.ExecuteAsync("Sp_save_rawdata",param:paramsObj, commandType: System.Data.CommandType.StoredProcedure);
                    
                }
            }
            catch (Exception ex)
            {
                //Error Log
                throw ex;
            }
        }
        public async Task<List<ScoreCount>> GetCountData()
        {
            try
            {
                List<ScoreCount> res = new List<ScoreCount>();
                using (SqlConnection con = new SqlConnection(@"Data Source=Akshay-PC\SQLEXPRESS;Initial Catalog=GPTW;Integrated Security=True"))
                {
                    var res2 = await con.QueryAsync<ScoreCount>("Sp_get_rawdataCount", commandType: System.Data.CommandType.StoredProcedure);
                    res = res2.ToList();
                }
                return res;
            }
            catch (Exception ex)
            {
                //Error Log
                throw ex;
            }
        }
     }
}
