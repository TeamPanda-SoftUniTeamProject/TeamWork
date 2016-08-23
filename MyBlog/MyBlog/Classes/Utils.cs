using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Classes
{
    public class Utils
    {
        public static string CutText(string text, int maxLenght = 100)
        {
            if (text == null || text.Length<=maxLenght)
                return text;
            var cutText = text.Substring(0, maxLenght)+" ";
            return cutText;
        }
    }
}