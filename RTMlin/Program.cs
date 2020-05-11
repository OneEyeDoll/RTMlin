using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using PS3Lib;
using PS3Lib.NET;
using PS3ManagerAPI;

namespace ConsoleApp1
{
     public class Program
    {
        public static string ConsoleTitle = "RTMlin Tool Alpha";


        //APIS

        public static PS3MAPI API = new PS3MAPI();

        //CONSOLE UI
        public static string top_padding = new string('=', Console.BufferWidth);
        public static string middle_padding = new string(' ', Console.BufferWidth);
        public static string middle_padding1 = new string(' ', Console.BufferWidth / 3);

        public static string middle_padding2 = new string(' ', Console.BufferWidth / 6);

        //HOST BOOLS
        public static bool isConnected = false;

        public static bool iSAttached = false;

        //NON HOST BOOLS
        public static bool SKYEDIT_enabled = false;
        public static bool NH_AmmoCheat_enabled = false;
        public static bool NH_GodMod_enabled = false;
        public static bool NH_func = false;
        public static bool NH_func2 = false;

        public static bool QuickNonHostEnhabled = false;
        
        //GAME PID
        public static uint GAME_PID=0;

        //COLORS
        public static ConsoleColor Connected_Color;
        public static ConsoleColor Attached_Color;
        public static ConsoleColor SKYEDIT_color;
        public static ConsoleColor AmmoCheat_color;
        public static ConsoleColor GodMod_color;
        public static ConsoleColor func_color;
        public static ConsoleColor func1_color;
        public static ConsoleColor CELL_temp_color;
        public static ConsoleColor RSX_temp;

        //Offsets byte arrays
        
        //Draw UI
        public static void DrawUI()
        {
            //Getting the boolean values, for the buttons color
            Connected_Color = !isConnected ? ConsoleColor.Red : ConsoleColor.Green;
            Attached_Color = !iSAttached ? ConsoleColor.Red : ConsoleColor.Green;
            AmmoCheat_color = !NH_AmmoCheat_enabled ? ConsoleColor.Red : ConsoleColor.Green;
            SKYEDIT_color = !SKYEDIT_enabled ? ConsoleColor.Red : ConsoleColor.Green;
            GodMod_color = !NH_GodMod_enabled ? ConsoleColor.Red : ConsoleColor.Green;
            func_color = !NH_func ? ConsoleColor.Red : ConsoleColor.Green;
            func1_color = !NH_func2 ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Title = ConsoleTitle;
            //Setting the UI
            Console.WriteLine(top_padding);
            Console.WriteLine(middle_padding2+"Welcome. Type \"/help\" for a list of commands.");
            Console.WriteLine(middle_padding);
            Console.Write(middle_padding1+"PS3 CONNECTED =>");
            Console.ForegroundColor = Connected_Color;
            Console.Write($"{isConnected.ToString()}");
            Console.ResetColor();
            Console.Write(middle_padding1 + "ATTACHED =>");
            Console.ForegroundColor = Attached_Color;
            Console.WriteLine($"{iSAttached.ToString()}");
            Console.ResetColor();
            Console.Write(middle_padding2+" Purple Sky =>");
            Console.ForegroundColor=SKYEDIT_color;
            Console.Write($"{SKYEDIT_enabled.ToString()}");
            Console.ResetColor();
            Console.Write(middle_padding2+" Infinite Ammos =>");
            Console.ForegroundColor=AmmoCheat_color;
            Console.Write($"{NH_AmmoCheat_enabled.ToString()}");
            Console.ResetColor();
            Console.Write(middle_padding2+" GodMod =>");
            Console.ForegroundColor=GodMod_color;
            Console.Write($"{NH_GodMod_enabled.ToString()}");
            Console.ResetColor();
            Console.Write(middle_padding2+" TBA =>");
            Console.ForegroundColor=func_color;
            Console.Write($"{NH_func.ToString()}");
            Console.ResetColor();
            Console.Write(middle_padding2+" TBA =>");
            Console.ForegroundColor=func1_color;
            Console.WriteLine($"{NH_func2.ToString()}");
            Console.ResetColor();
            Console.WriteLine(top_padding);


        }

        static void ConnectAPI()
        {
            try
            {
                //Takes IP Address in input, and connects through the ConnectTarget function
                Console.WriteLine("Insert IP Address please");
                string IPAddr = Console.ReadLine();
                API.ConnectTarget(IPAddr);
                isConnected = true;
                ConsoleTitle += "Connected!";
                Console.ForegroundColor = ConsoleColor.Green;
                API.PS3.Notify("Please don't cheat, this will ruin your fun!");
                Console.WriteLine("Succesfully connected, and please don't go in GTA Online cos i'm probably playing it rn.");
                Console.ResetColor();
            }
            catch (Exception e)
            {
                //If something fails, throws this error
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something bad happened during connection");
                Console.ResetColor();
            }

        }

        static void AttachProcess()
        {
            try
            {
                //Attach the first PID, which usually is the game PID
                uint[] GAMEPID=API.Process.GetPidProcesses();
                API.AttachProcess(GAMEPID[0]);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Process Attached successfully");
                GAME_PID = GAMEPID[0];
                iSAttached = true;
                Console.ResetColor();


            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something bad happened");
                Console.ResetColor();
            }
        }

        
        




        static void Main(string[] args)
        {
            Cheats cheats=new Cheats();
            bool EXIT_BOOL=true;
            do
            {
                
                DrawUI();
                Console.Write(">");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "/exit":
                        EXIT_BOOL = false;
                        break;
                    case "/connect":
                        ConnectAPI();
                        break;
                    case "/attach":
                        AttachProcess();
                        break;
                    case "/ammo":
                        cheats.InfiniteAmmo();
                        break;
                    case "/sky":
                        cheats.SkySelect();
                        break;
                    case "/god":
                        cheats.GodMod();
                        break;
                    case "/help":
                        Console.WriteLine("/exit -> Exits the tool\n/connect -> Connects to PS3MAPI\n/attach -> Attach the current game process\n/sky -> changes the sky color to purple\n/ammo -> Gives infinite ammos\n/god -> Toggles the GodMod");
                        break;
                    default:
                        Console.WriteLine("No existing command");
                        break;

                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            } while (EXIT_BOOL);


        }
    }
}