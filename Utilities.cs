using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingTables
{
    class Utilities
    {
        static List<TableDatacollection> _tableDatacollections = new List<TableDatacollection>();
        private static string columnValue;
        private static object cell;

        public static void ReadTable(IWebElement table)
        {
            //get cols from the table
            var columns = table.FindElements(By.TagName("state d tage name"));

            //get all the rows

            var rows = table.FindElements(By.TagName("state tag name"));

            //create row index
            int rowIndex = 0;

            foreach (var row in rows)
            {
                int colIndex = 0;
                var colDates = row.FindElements(By.TagName("state the tag"));

                foreach (var colValue in colDates)
                {
                    _tableDatacollections.Add(new TableDatacollection
                    {
                        RowNumber = rowIndex,
                        // ColumnName = columns[colIndex].Text,
                        ColumnName = columns[colIndex].Text != "" ?
                                     columns[colIndex].Text : colIndex.ToString(),

                        ColumnValue = colValue.Text,
                        ColumnSpecialValues = colValue.Text != "" ? null :
                                              colValue.FindElements(By.TagName("type the value"))
                    });

                    //move to next column
                    colIndex++;
                }

                rowIndex++;
            }

        }

        public static string ReadCell(string columnName, int rowNumber)
        {
            var data = (from e in _tableDatacollections
                        where e.ColumnName == columnName && e.RowNumber == rowNumber
                        select e.ColumnValue).SingleOrDefault();
            return data;


        }

        public static void PerformActionOnCell(string columnIndex, string refColumnName, string refColumnValue,
            string controlToOperate = null)
        {
            foreach (int rowNumber in GetDynamicRowNumber(refColumnName, refColumnValue))
            {
                var cell = (from e in _tableDatacollections
                            where e.ColumnName == columnIndex && e.RowNumber == rowNumber
                            select e.ColumnSpecialValues).SingleOrDefault();

            }


            //need to operate on those controls

            if (controlToOperate != null && cell != null)
            {
                var returnedControl = (from c in cell
                                       where c.GetAttribute("type the attribute") == controlToOperate
                                       select c).SingleOrDefault();

                returnedControl?.Click();

            }
            else
            {
                if(cell!=null)cell.First().Click();
            }

        }
    


        private static IEnumerable GetDynamicRowNumber(string columnName,string columnvalue)
        {
            //dynamic row 
            foreach (var table in _tableDatacollections)
            {
                if (table.ColumnName == columnName && table.ColumnValue == columnValue)
                     yield return table.RowNumber;

            }
        }

    }

    public class TableDatacollection
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }

        public IEnumerable<IWebElement> ColumnSpecialValues { get; set; }

    }
}
