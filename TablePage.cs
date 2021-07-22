using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingTables
{
    public class TablePage : Base
    {
        public TablePage()
        {
            PageFactory.InitElements(Driver,this);

        }

        public TablePage(IWebElement table)
        {
            this.table = table;
        }

        [FindsBy(How = How.XPath,Using ="the path of the table u intend to use")]
        public IWebElement table { get; set; }
            
        

    }
}
