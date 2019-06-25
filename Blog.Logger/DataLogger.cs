using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Blog.Logger
{
    public static class DataLogger
    {
        const string path = @"Libraries\Documents\Logging.txt";

        public static void Log(string data)
        {
            using(var writer = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate)))
            {
                writer.WriteLine(data);
            }
        }
    }
}
