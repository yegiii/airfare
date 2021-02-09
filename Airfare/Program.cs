using System;
using System.IO;
using System.Text;

namespace airfare
{
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
            string[] flight_info = new string[5];
            string path = @"D:\my C#\airfare\Airfare\Airfare\Admin\flights.txt";

            if (!File.Exists(path)) 
            {
                create_file(path);
                Console.WriteLine("File created");
            }
                
            Console.Clear();
            Console.WriteLine("_____________________________________________ ADMIN _____________________________________________");
            Console.WriteLine("\tEnter the name of airline you want to add : ");
            flight_info[0] = Console.ReadLine();
            Console.WriteLine("\tEnter the date of flight : (like yyyy/mm/dd )");
            flight_info[1] = Console.ReadLine();
            Console.WriteLine("\tEnter the time of flight : ");
            flight_info[2] = Console.ReadLine();
            Console.WriteLine("\tEnter the beginning of flight : ");
            flight_info[3] = Console.ReadLine();
            Console.WriteLine("\tEnter the destination of flight : ");
            flight_info[4] = Console.ReadLine();

            write_file(path, flight_info);
            
        }

        //admin wants to add a food
        static void add_food()
        {
            string[] food_info = new string[1];
            string path = @"D:\my C#\airfare\Airfare\Airfare\Admin\foods.txt";

            if (!File.Exists(path))
            {
                create_file(path);
                Console.WriteLine("File created");
            }

            Console.Clear();
            Console.WriteLine("_____________________________________________ ADMIN _____________________________________________");
            Console.WriteLine("\tEnter the name of food you want to add : ");
            food_info[0] = Console.ReadLine();
            

            write_file(path, food_info);
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
            string path = @"D:\my C#\airfare\Airfare\Airfare\Admin\flights.txt";
            Console.Clear();
            Console.WriteLine("_____________________________________________ ADMIN _____________________________________________");
            show_file(path);
            Console.WriteLine("/tPlease enter the name of flight that you want to edit : ");
            string search_flight_name = Console.ReadLine();




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
        static void write_file(string path, string[] info)
        {
            // Open the stream and write to it.
            if( info.Length == 5)
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine( info[0] +"\t"+ info[1] + "\t" + info[2] + "\t" + info[3] + "\t" + info[4]);
                    Console.WriteLine("\n\tDONE!!!\n\tplease press a key to continiue.");
                    Console.ReadLine();
                }
            }
            
            if( info.Length == 1)
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(info[0]);
                }
            }
            
        }

        //show whole of file
        static void show_file(string path)
        {
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(path);

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

        static void search( string Path , string search_name)
        {
             
        }

        static void user()
        {

        }

    }
}
