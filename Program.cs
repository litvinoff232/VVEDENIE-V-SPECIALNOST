using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Threading.Tasks.Dataflow;
namespace LubC{
    class Programm
    {
        static void Main(string[] args)
        {


            try{
                Func func = new Func();
                Random rnd = new Random();
                bool flag = true;
                while (flag)
                {
                    func.menu();
                    double menu = func.checkString(Console.ReadLine() ?? "");
                    switch ((int)menu)
                    {
                        case 1:

                            func.caseOne();
                            break;
                        case 2:
                            func.gameTwo();
                            break;

                        case 3:
                            func.caseThree();
                            break;

                        case 4:
                            flag = func.doExit();
                            break;

                        default:
                            Console.WriteLine("несуществующий пункт меню");
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("END PROGRAM");
            }
        }
    }
}


