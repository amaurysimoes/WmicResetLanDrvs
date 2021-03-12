using System;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

//Pesquisa de comandos Wmic:
//https://www.intel.com.br/content/www/br/pt/support/articles/000025060/intel-nuc.html

namespace WMIC
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deve seguir esta ordem!
            //Inicializa o método a seguir para executar verificação
            ExecutarProcessoParaLerEntradaPadrao();
            //Abre o modo console do projeto
            Console.ReadLine();
        }

        public static void ExecutarProcessoParaLerEntradaPadrao()
        {
            Process application = new Process();
            // Executa o comando shell.
            application.StartInfo.FileName = @"cmd.exe";
            // Ativa as extensões de command para cmd.exe.
            application.StartInfo.Arguments = "/E:ON";
            application.StartInfo.RedirectStandardInput = true;
            application.StartInfo.UseShellExecute = false;
            application.Start();
            StreamWriter input = application.StandardInput;
            System.Threading.Thread.Sleep(1000);
            input.WriteLine("@echo==Desativar e Reativar placa de rede==");
            input.WriteLine("cd..");
            input.WriteLine("cd..");
            input.WriteLine("cd..");
            input.WriteLine("cd..");
            input.WriteLine("cd..");
            input.WriteLine("cd..");
            input.WriteLine("cd..");
            //System.Threading.Thread.Sleep(1000);
            input.WriteLine("wmic nic get name, index");
            input.WriteLine("wmic path win32_networkadapter where index=1 call disable");
            input.WriteLine("wmic path win32_networkadapter where index=8 call disable");
            input.WriteLine("wmic path win32_networkadapter where index=9 call disable");
            input.WriteLine("wmic path win32_networkadapter where index=11 call disable");
            //System.Threading.Thread.Sleep(1000);
            input.WriteLine("wmic path win32_networkadapter where index=1 call enable");
            input.WriteLine("wmic path win32_networkadapter where index=8 call enable");
            input.WriteLine("wmic path win32_networkadapter where index=9 call enable");
            input.WriteLine("wmic path win32_networkadapter where index=11 call enable");
            System.Threading.Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }
}