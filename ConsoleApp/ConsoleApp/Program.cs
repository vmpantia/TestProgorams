using ConsoleApp.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                TestTableTableAdapter testTableTableAdapter = new TestTableTableAdapter();
                testTableTableAdapter.DeleteQuery(1);

                DataSet1.TestTableDataTable dtTest = new DataSet1.TestTableDataTable();
                DataSet1.TestTableRow dataRow1 = dtTest.NewTestTableRow();
                dataRow1.PK1 = 1;
                dataRow1.PK2 = 2;
                dataRow1.Value = "3";
                DataSet1.TestTableRow dataRow2 = dtTest.NewTestTableRow();
                dataRow2.PK1 = 1;
                dataRow2.PK2 = 3;
                dataRow2.Value = "4";
                DataSet1.TestTableRow dataRow3 = dtTest.NewTestTableRow();
                dataRow3.PK1 = 1;
                dataRow3.PK2 = 4;
                dataRow3.Value = "5";
                DataSet1.TestTableRow dataRow4 = dtTest.NewTestTableRow();
                dataRow4.PK1 = 1;
                dataRow4.PK2 = 5;
                dataRow4.Value = "6";
                DataSet1.TestTableRow dataRow5 = dtTest.NewTestTableRow();
                dataRow5.PK1 = 1;
                dataRow5.PK2 = 2;
                dataRow5.Value = "7";

                dtTest.AddTestTableRow(dataRow1);
                dtTest.AddTestTableRow(dataRow2);
                dtTest.AddTestTableRow(dataRow3);
                dtTest.AddTestTableRow(dataRow4);
                dtTest.AddTestTableRow(dataRow5);

                testTableTableAdapter.Update(dtTest);

                transactionScope.Complete();
            }
        }
    }
}
