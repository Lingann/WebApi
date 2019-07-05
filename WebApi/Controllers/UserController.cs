using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using MySql.Data.MySqlClient;
namespace WebApi.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        [HttpGet] [Route("Login")]
        public string Login(LoginViewModel model)
        {
            return "ok";
        }

        // 使用查询字符串进行传入参数 QueryString   api/user?name=****
        public string Get(string name)
        {
            return "获取传入的参数" + name;
        }


        [HttpGet]
        [Route("GetMessage")]
        public IHttpActionResult GetMessage()
        {
            // OK()
            // NotFound()
            //

            return NotFound(); ;
        }

        // POST api/values
        public void Post(User user)
        {
            // 创建数据库连接
            MySqlConnection conn = WebApiConfig.conn(); ;
            // 创建一条命令
            MySqlCommand query = conn.CreateCommand();
            // 编写数据库操作命令
            query.CommandText = "insert into"
                + " tbl_user"
                + " values('"
                + user.user_name + "','"
                + user.age + "','"
                + user.signup_date + "','"
                + user.email+"')" ;
            // 执行数据库操作命令
            MySqlDataReader fetch_query = query.ExecuteReader();
        }

    }
}
