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
        // 连接数据库
        public static MySqlConnection conn()
        {
            string conn_string = "server=localhost;port=3306;database=webapi_db;username=root;password=;";

            MySqlConnection connect = new MySqlConnection(conn_string);

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
