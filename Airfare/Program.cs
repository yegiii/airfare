using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace airfare
{
    // static class to hold global variables, etc.
    static class Globals
    {
        // global int
        public static string flight_counter = "0";
        public static string food_counter = "0";

        // global function
        public static string HelloWorld()
        {
            return "Hello World";
        }
    }

    class Program
    {
        //main method( u know it :) )
        static void Main(string[] args)
        {
            login();
        }

        //login
        static void login()
        {
            bool on = true;
            while (on)
            {
                on = false;
                Console.Clear();
                Console.WriteLine("Hello...");
                Console.WriteLine("You Are : ");
                Console.WriteLine("\t 1 - Admin");
                Console.WriteLine("\t 2 - User");
                Console.WriteLine("\t 3 - Nothing :)");
                Console.WriteLine("( Enter the number )");

                int login_as = Convert.ToInt32(Console.ReadLine());

                switch (login_as)
                {
                    case 1:
                        admin();
                        on = true;
                        break;
                    case 2:
                        user();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\tWrong! please press a key to try again.");
                        Console.ReadLine();
                        on = true;
                        break;
                }
            }
        }

        //anything is admins hand
        static void admin()
        {
            bool on = true;
            while (on)
            {
                on = false;
                Console.Clear();
                Console.WriteLine("_____________________________________________ ADMIN _____________________________________________");
                Console.WriteLine("\t 1 - Add");
                Console.WriteLine("\t 2 - Edit");
                Console.WriteLine("\t 3 - Remove");
                Console.WriteLine("\t 4 - Back");
                Console.WriteLine("\n\tEnter the number : ");
                int admin_des = Convert.ToInt32(Console.ReadLine());

                switch (admin_des)
                {
                    case 1:
                        add_admin();
                        break;
                    case 2:
                        edit_admin();
                        break;
                    case 3:
                        Console.WriteLine("Remove");
                        break;
                    case 4:
                        //back
                        return;
                        break;
                    default:
                        Console.WriteLine("\tWrong! please press a key to try again.");
                        Console.ReadLine();
                        on = true;
                        break;
                }
            }
        }

        //admin wants to add anything
        static void add_admin()
        {
            bool on = true;
            while (on)
            {
                on = false;
                Console.Clear();
                Console.WriteLine("_____________________________________________ ADMIN _____________________________________________");
                Console.WriteLine("\t 1 - Add Flight");
                Console.WriteLine("\t 2 - Add Food");
                Console.WriteLine("\t 3 - Add Ticket");
                Console.WriteLine("\t 4 - Back");
                Console.WriteLine("\n\tEnter the number : ");
                int admin_des = Convert.ToInt32(Console.ReadLine());

                switch (admin_des)
                {
                    case 1:
                        add_flight();
                        break;
                    case 2:
                        add_food();
                        break;
                    case 3:
                        Console.WriteLine("Add Ticket");
                        return;
                        break;
                    case 4:
                        //back
                        return;
                        break;
                    default:
                        Console.WriteLine("\tWrong! please press a key to try again.");
                        Console.ReadLine();
                        on = true;
                        break;
                }
            }
        }

        //admin wants to add a flight
        static void add_flight()
        {
            var flight_info = new Dictionary<string, string>();

            string filename = @"D:\my C#\airfare\Airfare\Airfare\Admin\flights.txt";

            if (!File.Exists(filename)) 
            {
                create_file(filename);
                Console.WriteLine("File created");
            }
                
            Console.Clear();
            Console.WriteLine("_____________________________________________ ADMIN _____________________________________________");
            Console.WriteLine("\tEnter the name of airline you want to add : ");
            string flight_name = Console.ReadLine();
            Console.WriteLine("\tEnter the date of flight : (like yyyy/mm/dd )");
            string flight_date = Console.ReadLine();
            Console.WriteLine("\tEnter the time of flight : ");
            string flight_time = Console.ReadLine();
            Console.WriteLine("\tEnter the beginning of flight : ");
            string flight_begining = Console.ReadLine();
            Console.WriteLine("\tEnter the destination of flight : ");
            string flight_destination = Console.ReadLine();

            //Globals.flight_counter++;

            flight_info.Add(Globals.flight_counter, flight_name + " " + flight_date + " " + flight_time + " " + flight_begining + " " + flight_destination);

            foreach (var flight in flight_info)
                Console.WriteLine("Key : {0} , Value : {1}", flight.Key , flight.Value);
            
            write_file( filename , flight_info);
        }

        //admin wants to add a food
        static void add_food()
        {
            var food_info = new Dictionary<string, string>();
            string filename = @"D:\my C#\airfare\Airfare\Airfare\Admin\foods.txt";

            if (!File.Exists(filename))
            {
                create_file(filename);
                Console.WriteLine("File created");
            }

            Console.Clear();
            Console.WriteLine("_____________________________________________ ADMIN _____________________________________________");
            Console.WriteLine("\tEnter the name of food you want to add : ");
            string food_name = Console.ReadLine();

            //Globals.food_counter++;

            food_info.Add(Globals.food_counter, food_name);

            foreach (var flight in food_info)
                Console.WriteLine("Key : {0} , Value : {1}", flight.Key, flight.Value);

            write_file(filename, food_info);
        }

        //admin wants to add a ticket
        static void add_ticket()
        {
            //aval bara user ro benevisam bad biam soragh in ke btone add kone
        }

        static void edit_admin()
        {
            bool on = true;
            while (on)
            {
                on = false;
                Console.Clear();
                Console.WriteLine("_____________________________________________ ADMIN _____________________________________________");
                Console.WriteLine("\t 1 - Edit Flight");
                Console.WriteLine("\t 2 - Edit Food");
                Console.WriteLine("\t 3 - Edit Ticket");
                Console.WriteLine("\t 4 - Back");
                Console.WriteLine("\n\tEnter the number : ");
                int admin_des = Convert.ToInt32(Console.ReadLine());

                switch (admin_des)
                {
                    case 1:
                        edit_flight();
                        break;
                    case 2:
                        //add_food();
                        break;
                    case 3:
                        Console.WriteLine("Add Ticket");
                        return;
                        break;
                    case 4:
                        //back
                        return;
                        break;
                    default:
                        Console.WriteLine("\tWrong! please press a key to try again.");
                        Console.ReadLine();
                        on = true;
                        break;
                }
            }
        }


        static void edit_flight()
        {
            string filename = @"D:\my C#\airfare\Airfare\Airfare\Admin\flights.txt";

            Console.Clear();
            Console.WriteLine("_____________________________________________ ADMIN _____________________________________________");
            show_file(filename);
            Console.WriteLine("\tPlease enter the name of flight that you want to edit : ");
            string search_flight_name = Console.ReadLine();
            search(filename, search_flight_name);



        }

        //create a file that didnt exist
        static void create_file(string path)
        {
            //string path = @".\Admin\Test.txt";

            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream test = File.Create(path))
                {
                    //byte[] info = new UTF8Encoding(true).GetBytes("");
                    // Add some information to the file.
                    //test.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                //if the path didnt find
                Console.WriteLine(ex.ToString());
            }
        }

        //write anything to file
        static void write_file( string filename, Dictionary<string ,string> flight_info)
        {
            
            // Open the stream and write to it.
            if ( Path.GetFileName(filename) == "flights.txt")
            {
                using (StreamWriter sw = File.AppendText(filename))
                {
                    foreach (var info in flight_info)
                        sw.WriteLine("{0} {1}", info.Key, info.Value);
                }
            }
            
            
           if(Path.GetFileName(filename) == "foods.txt")
           {
                using (StreamWriter sw = File.AppendText(filename))
                {
                    foreach (var info in flight_info)
                        sw.WriteLine("{0} {1}", info.Key, info.Value);
                }
           }

            Console.WriteLine("\n\tDONE!!!\n\tplease press a key to continiue.");
            Console.ReadLine();
        }

        //show whole of file
        static void show_file(string filename)
        {
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(filename);

            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("\tList of flights = ");
            int count = 0;
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                count++;
                Console.WriteLine("\t\t" + count + " - " + line);
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to continue.");
            System.Console.ReadKey();
        }

        static void search( string filename , string search_name)
        {
            var new_flights = new Dictionary<string, string>();

            string[] lines = System.IO.File.ReadAllLines(filename);


            for (int i=0 ; i < lines.Length; i++)
            {
                if(lines[i].Contains(search_name))
                {
                    Console.WriteLine("_____________________________________________ ADMIN _____________________________________________");
                    Console.WriteLine("\tEnter the name of airline you want to add : ");
                    string flight_name = Console.ReadLine();
                    Console.WriteLine("\tEnter the date of flight : (like yyyy/mm/dd )");
                    string flight_date = Console.ReadLine();
                    Console.WriteLine("\tEnter the time of flight : ");
                    string flight_time = Console.ReadLine();
                    Console.WriteLine("\tEnter the beginning of flight : ");
                    string flight_begining = Console.ReadLine();
                    Console.WriteLine("\tEnter the destination of flight : ");
                    string flight_destination = Console.ReadLine();

                    lines[i] = ("0 " + flight_name + " " + flight_date + " " + flight_time + " " + flight_begining + " " + flight_destination);

                    Console.WriteLine("\n\tDONE!!!\n\tplease press a key to continiue.");
                    Console.ReadLine();
                }

                string[] lmnts = lines[i].Split(' ','\t');
                foreach (var lmnt in lmnts) Console.WriteLine(lmnt);
                new_flights.Add(lmnts[0], lmnts[1] + " " + lmnts[2] + " " + lmnts[3] + " " + lmnts[4] + " " + lmnts[5]);
            }

            write_file(filename , new_flights);
        }

        static void user()
        {

        }

    }
}
