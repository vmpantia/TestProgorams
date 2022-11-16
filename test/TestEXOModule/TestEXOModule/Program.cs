using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace TestEXOModule
{
    internal class Program
    {
        static void Main(string[] args)
        {

            PowerShell pwrShell = PowerShell.Create();

            PSCommand cmd = new PSCommand();
            cmd.AddCommand("Import-Module ExchangeOnlineManagement");
            pwrShell.Commands = cmd;
            pwrShell.Invoke();

            cmd = new PSCommand();
            cmd.AddCommand("Connect-ExchangeOnline");
            pwrShell.Commands = cmd;
            pwrShell.Invoke();

            pwrShell.Dispose();

            Console.ReadKey();

        }
    }
}
