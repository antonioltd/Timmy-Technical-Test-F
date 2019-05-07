using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class AppSettings
    {
        public static string BaseUrl = GetValue("BaseUrl");

        public static string Users = GetValue("Users");

        public static string Comments = GetValue("Comments");

        public static string Albums = GetValue("Albums");

        public static string Photos = GetValue("Photos");

        public static string Todos = GetValue("Todos");

        public static string Posts = GetValue("Posts");


        private static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
