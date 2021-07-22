using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingTables
{
    class Program : Base
    {

        public Program()
        {
            Driver = new FirefoxDriver();
            Driver.Navigate().GoToUrl("state the path to your table or link to the url");


        }
        static void Main(string[] args)
        {
            Program p = new Program();
            TablePage page = new TablePage();
            //Read table
            Utilities.ReadTable(page.table);
            Console.WriteLine("********************************");
            //get cell value from table

            // Console.WriteLine(Utilities.ReadCell("colname,rownumber-email", 1));
            Console.WriteLine("The name {0} with email {1} and phone {2}",
               Utilities.ReadCell("Name", 2), Utilities.ReadCell("Email", 2), Utilities.ReadCell("Phone", 2)

            Console.WriteLine("********************************");
           
            //Delete Preshant
            Utilities.PerformActionOnCell("5", "Name", "Preshanth", "Delete");


            Console.Read();

        }
    }
}
