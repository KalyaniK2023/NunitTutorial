using NunitTutorial.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using OfficeOpenXml;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;
using System.Reflection;
using System.Collections.Generic;
using OpenQA.Selenium;


namespace NunitTutorial.Helper
{
    public class ReadDataExcel
    {
        string _filePath;
        private List<Login> loginlist;
        
        

        public ReadDataExcel(string projectName, string excelTestDataFileName)
        {
            var dirPath = Assembly.GetExecutingAssembly().Location;
            int index = dirPath.IndexOf(projectName);
            _filePath = dirPath.Remove(index) + "\\NunitTutorial\\" + projectName + "\\Asset\\" + excelTestDataFileName + ".xlsx";
        }

        public ReadDataExcel(string filePath)
        {
            _filePath = filePath;
        }

       
        public  List<Login> GetTestData(string sheetName)
        {
            
          var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=2\'", _filePath);

            var adapter = new OleDbDataAdapter(string.Format("select * from [Sheet1$]"), connectionString);
            var ds = new DataSet();
            // adapter.TableMappings.Add("Table", "TestTable");
            adapter.Fill(ds,sheetName);
            var dt= ds.Tables["Sheet1"];
            Login login = new Login();
            List<Login> loginlist = new List<Login>();
            for (int i = 0; i < dt.Rows.Count-1; i++)
            {
                login.UserName = dt.Rows[i][0].ToString();
                login.Password = dt.Rows[i][1].ToString();
                //login.URL = dt.Rows[i][2].ToString();
                loginlist.Add(login);
            }
            return loginlist;


        }
        public static List<Login> GetArrayData(System.Data.DataTable dt)
        {
            Login login=new Login();
            List<Login> loginlist=new List<Login>();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                login.UserName = dt.Rows[i][0].ToString();
                login.Password = dt.Rows[i][1].ToString();
                login.URL = dt.Rows[i][2].ToString();
                loginlist.Add(login);
            }
            return loginlist;
        }

        }
}
