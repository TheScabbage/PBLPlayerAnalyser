using System;
using System.IO;

namespace CSVConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 1)
            {
                return;
            }
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("No such file exists.");
            }
            else
            {
                string result = "";
                try
                {

                    using (StreamReader fs = File.OpenText(args[0]))
                    {
                        string header = fs.ReadLine();
                        string line = fs.ReadLine();

                        while (line != null)
                        {
                            result += line;

                            line = fs.ReadLine();

                            if (line != null)
                            {
                                result += "\\n";
                            }
                        }
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }

                try
                {
                    if(!File.Exists(args[1]))
                    {
                        File.Create(args[1]);
                    }
                    using (StreamWriter fs = new StreamWriter(args[1]))
                    {
                        fs.Write(result);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
