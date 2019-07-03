using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Cors;
using System.Web.Http.Cors;
using MySql.Data.MySqlClient;

namespace WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            MySqlConnection conn = WebApiConfig.conn();

            // 数据库命令
            MySqlCommand query = conn.CreateCommand();

            query.CommandText = "SELECT user_name FROM tbl_user";
            try
            {
                conn.Open();
            }
            catch(MySqlException ex)
            {
                return "failure" + ex;
            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            while (fetch_query.Read())
            {
                return fetch_query["user_name"].ToString();
            }

            return "Its done!";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
