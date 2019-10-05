using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordEncryption
{
    class App
    {
        
        
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------");

            Console.WriteLine("      \nPassword Autherntication System:");
            Console.WriteLine("      \nSelect an option below:");
            Console.WriteLine("      1. Establish an account\n      2. Authenticate a user\n      3. Exit the system");
            Console.Write("      Enter Selection: ");

           
            string inputS = Console.ReadLine();

          
            try
            {
                int input = int.Parse(inputS);

                if (input == 1)
                {
                    MakeAccount();
                }
                else if (input == 2)
                {
                    Authenticate();
                }
                else if (input == 3)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine();
                    Console.ReadLine();
                    Menu();
                }


            }
            catch (FormatException)
            {
                Console.WriteLine("Your entry was not a valid selecetion:");
                Menu();
            }

           
        }

        private void MakeAccount()
        {
            string username = "";
            string password = "";
            try
            {
                Console.Clear();
                Console.Write("Please Enter Desired Username: ");
                username = Console.ReadLine();

                Console.Write("Please Enter A Password: ");
                password = Console.ReadLine();
                Console.WriteLine($"\nYou have entered the Username: {username} and the Passwoed: {password}");
                Console.WriteLine("Press (1) to confirm and (2) to return to menu");
                int input = int.Parse(Console.ReadLine());

                if (input == 1)
                {
                    Users.UserInput(username, password);
                }
                else
                {
                  Menu();
                }
                Console.WriteLine($"User {username} was sucessfully added with the password: (SHA256 Hash): {Users.userAccount[username]} ");

            }
            catch (ArgumentException)
            {
                Console.WriteLine("\nThat username is already in the System, try again.");
                Console.WriteLine("\nPress any key to continue:");
                Console.ReadKey();
            }
            finally
            {
                Menu();
            }





        }

        private void Authenticate()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("AUTHENTICATE A USER:\n");
                Console.Write("Enter username: ");
                string username = Console.ReadLine();

                bool correct = false;
                int count = 3;
                do
                {
                    Console.Write("Enter Password: ");
                    string pass = Console.ReadLine();
                    pass = Users.GetHash(pass);
                    var hashedPass = Users.userAccount[username];
                    if (pass == hashedPass)
                    {
                        Console.WriteLine("Password verified as correct!");
                        Console.Write("Press any key to continue: ");
                        Console.ReadKey();
                        correct = true;
                        
                    }
                    else
                    {
                        count--;
                        Console.WriteLine($"Incorrect Password, you have {count} attempts remaining.");

                    }

                } while (correct == false && count != 0);


            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("\nThat username is not in the system");
                Console.Write("\nPress any key to continue: ");
                Console.ReadKey();
            }
            finally
            {
                Menu();
            }
        }

        //from Robs to verify the hash - very useful
      



    }






}
