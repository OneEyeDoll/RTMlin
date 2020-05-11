using System;
using ConsoleApp1;

namespace ConsoleApp1
{
    public class Cheats
    {
        //SKIES OFFSETS
        public static byte[] PurpleSkies = {0xF4, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x18, 0x19, 0x1A, 0x1B, 0xF8};

        public static byte[] NormalSkies = {0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x18, 0x19, 0x1A, 0x1B, 0xF8};
        //AMMOS OFFSETS
        private byte[] infiniteAmmos = {0x3B, 0xA0, 0x27, 0x72};
        private byte[] finiteAmmos = {0x63, 0xFD, 0x00, 0x00};
        //GODMOD BYTES
        private byte[] GodModOn = {0x38, 0x60, 0x7F, 0xFF, 0xB0, 0x7F, 0x00, 0xB4};
        private byte[] GodModOff = { 0xFC, 0x01, 0x10, 0x00, 0x41, 0x80, 0x01, 0x14};
        
        public void GodMod()
        {
            Console.WriteLine(@"Please write ON to turn on the mod, else write OFF to turn off");
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "on":
                    try
                    {
                        uint GodModAddress = 0x1189728;
                        Program.API.Process.Memory.Set(Program.GAME_PID, GodModAddress, GodModOn);
                        Program.NH_GodMod_enabled = true;
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error during the operation.");
                        Console.ResetColor();
                    }

                    break;
                case "off":
                    try
                    {
                        uint GodModAddress = 0x1189728;
                        Program.API.Process.Memory.Set(Program.GAME_PID, GodModAddress, GodModOff);
                        Program.NH_GodMod_enabled = false;
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error during the operation.");
                        Console.ResetColor();
                    }

                    break;
                default:
                    Console.WriteLine(@"Please write ON for turning on the mod, else write OFF for turning off");
                    break;

            }
        }
        
        


        public void InfiniteAmmo()
        {
            Console.WriteLine(@"Please write ON to turn on the mod, else write OFF to turn off");
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "on":
                    try
                    {
                        uint AmmoAddress = 0xFD2AE4;
                        Program.API.Process.Memory.Set(Program.GAME_PID, AmmoAddress, infiniteAmmos);
                        Program.NH_AmmoCheat_enabled = true;
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error during the operation.");
                        Console.ResetColor();
                    }

                    break;
                case "off":
                    try
                    {
                        uint AmmoAddress = 0xFD2AE4;
                        Program.API.Process.Memory.Set(Program.GAME_PID, AmmoAddress, finiteAmmos);
                        Program.NH_AmmoCheat_enabled = false;
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error during the operation.");
                        Console.ResetColor();
                    }

                    break;
                default:
                    Console.WriteLine(@"Please write ON for turning on the mod, else write OFF for turning off");
                    break;

            }
        }

        public void SkySelect()
        {
            Console.WriteLine(@"Please write ON for turning on the mod, else write OFF for turning off");
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "on":
                    try
                    {
                        uint SkyColor = 0x4937C4;
                        Program.API.Process.Memory.Set(Program.GAME_PID, SkyColor, PurpleSkies);
                        Program.SKYEDIT_enabled = true;
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error during the operation.");
                        Console.ResetColor();
                    }

                    break;
                case "off":
                    try
                    {
                        uint SkyColor = 0x4937C4;
                        Program.API.Process.Memory.Set(Program.GAME_PID, SkyColor, NormalSkies);
                        Program.SKYEDIT_enabled = false;
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error during the operation.");
                        Console.ResetColor();
                    }

                    break;
                default:
                    Console.WriteLine(@"Please write ON for turning on the mod, else write OFF for turning off");
                    break;
            }
        }
    }
}