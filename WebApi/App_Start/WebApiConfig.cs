using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Cors;
using System.Web.Http;
using System.Web.Http.Cors;
using MySql.Data.MySqlClient;
namespace WebApi
{
    public static class WebApiConfig
    {
        #region 数据库连接配置
        /*****************数据库配置************************/
        struct DBConfig {
            public static string server = "localhost";         // 服务器
            public static string port = "3306";                    // 端口号
            public static string database = "webapi_db";   // 数据库
            public static string username = "root";            //用户名
            public static string password = "";                    //密码
        }

        static string conn_string
        {
            get
            {
                string param = "";
                param += "server=" + DBConfig.server;
                param += ";port=" + DBConfig.port;
                param += ";database=" + DBConfig.database;
                param += ";username=" + DBConfig.username;
                param += ";password=" + DBConfig.password;
                param += ";";
                return param;
            }
        }
        #endregion

        // 连接数据库
        public static MySqlConnection conn()
        {
            MySqlConnection connect = new MySqlConnection(conn_string);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                connect.Open();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            connect.Clone();
            return connect;
        }

        public static void Register(HttpConfiguration config)
        {
            // 跨域配置
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
