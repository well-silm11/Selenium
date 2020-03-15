using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumNigga
{
    public class AcessFacebook
    {


        public static void RequestFacebook(List<string> fv)
        {
            ChromeOptions options = new ChromeOptions();
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.SuppressInitialDiagnosticInformation = true;

            IWebDriver driver = null;
           
            using (driver = new ChromeDriver(service, options))
            {
            
      
                List<string> resul = new List<string>();
                driver.Url="https://pt-br.facebook.com";
                driver.Manage().Window.Maximize();
                driver.FindElement(By.ClassName("login_form_label_field"));

                var link = driver.FindElements(By.TagName("td"))[6];
                
                link.Click();

                
                Thread.Sleep(3000);
                foreach (var item in fv)
                {
                    var count = 0;

                    driver.FindElement(By.Id("identify_email")).SendKeys(item+Keys.Enter);
                    Thread.Sleep(3000);

                    IList<IWebElement> webs = driver.FindElements(By.XPath("//div[@class='fsl fwb fcb']")).ToList();



                    if (webs[count].Text== "Nenhum resultado para a pesquisa")
                    {
                        Console.WriteLine("O E-mail ou Telefone: "+item+"  não retornou nenhum perfil\n Aperte qualquer tecla para ir para o próximo");
                        Console.ReadKey();
                    
                    }
                    else
                    {
                        Console.WriteLine("Perfil encontrado com "+item+ ", o nome é: "+webs[count].Text+ "\n Aperte qualquer tecla para ir para o próximo");
                        Console.ReadKey();
                        driver.FindElements(By.Name("reset_action"))[1].Click();
                    }
                    count++;
                    Console.Clear();

                }
                Console.WriteLine("Pronto! todos os itens da lista em csv fora verificados, flw parça!");
                Console.ReadKey();
            }
        }
    }
}
