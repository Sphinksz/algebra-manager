﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swgemu_live_reader
{
    class Program
    {
        static void Main(string[] args)
        {
            //reading and loading all of swgemu_live
            string value1 = File.ReadAllText("C://Program Files (x86)/SWGEmu/SWGEmu/swgemu_live.cfg");
            Console.WriteLine("----swgemu_live----");
            Console.WriteLine(value1);

            //reading Max Search prioirty line in swgemu_live
            string value2 = File.ReadLines("C://Program Files (x86)/SWGEmu/SWGEmu/swgemu_live.cfg").Skip(2).Take(1).First();
            Console.WriteLine("----Max Search Priority----");
            Console.WriteLine(value2);

            //reading mods in mod folder
            DirectoryInfo d = new DirectoryInfo("C://Program Files (x86)/SWGEmu/SWGEmu/mod/");//Assuming you have a swgemu\mod folder
            FileInfo[] Files = d.GetFiles("*.tre"); //Getting Text files
            string str = "";
            foreach (FileInfo file in Files)
            {
                str = str + System.Environment.NewLine + file.Name;//pastes every tre file name on a new line
            }
            Console.WriteLine("----mods in mod folder----");
            Console.WriteLine(str);

            //getting Max Search Priority as an integer
            //using value2
            string value3 = value2;
            var max = value3.Substring(value3.LastIndexOf('=') + 1); //find the values behind the = after max search priority
            Console.WriteLine("----Max Search Priority value----");
            Console.WriteLine(max);

            //reading Max Search prioirty line in swgemu_live
            int x = 0;
            Int32.TryParse(max, out x); //makes max a number
            x = x + 25; //cause soe makes things equal in load order, idiots
            var value4 = File.ReadLines("C://Program Files (x86)/SWGEmu/SWGEmu/swgemu_live.cfg").Skip(3).Take(x).ToArray(); //takes all the tre files in swgemu_live
            Console.WriteLine("----List of all active tre files----");
            Console.WriteLine(value4);
            foreach (string tre in value4)
            {
                string[] fix = tre.Split('=');
                Console.WriteLine(fix[1]);
            }//no idea how it works but this shows the ToArray() as lines and writes it
            List<string> mods = new List<string>();
            foreach (string tre in value4)
            {
                string[] fix = tre.Split('=');
                if (fix[1].Contains(@"mod\"))
                    {
                    mods.Add(fix[1]);
                }
                else
                {
                    Console.WriteLine(fix[1]);
                }//writes the non mods
            }
            Console.WriteLine("----Active Mods----");
            foreach (string mod in mods)//and writes it
            {
                Console.WriteLine(mod);
            }
            Console.WriteLine("enter to exit");
            Console.ReadKey();


        }
    }
}
