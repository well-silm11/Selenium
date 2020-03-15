using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SeleniumNigga
{
    class Program
    {
        static void Main(string[] args)
        {


            List<string> email = null;
            while (email==null)
            {
                Console.Clear();
                var caminho = "";
                Console.WriteLine("Olá!\n Digite o caminho onde se encontra o csv:\n");
                caminho = Console.ReadLine();



                email = ConvertSCV(caminho);
            }

            AcessFacebook.RequestFacebook(email);

        }

        private static List<string> ConvertSCV(string caminho)
        {
            try
            {
                StreamReader reader = new StreamReader(File.OpenRead(caminho));
                List<string> listA = new List<String>();

                while (!reader.EndOfStream)
                {
                    var a = 0;
                    string line = reader.ReadLine();
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        string[] values = line.Split(';');
                        if (values.Length >= 2)
                        {
                            listA.Add(values[a]);
                            a++;
                            listA.Add(values[a]);
                        }
                    }
                }
                string[] firstlistA = listA.ToArray();

                return listA.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Este caminho informado não retorna um csv válido, veirifique se está correto e tente novamente");
                Console.ReadKey();
                return null;
            }
        }
    }
}
