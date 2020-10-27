using SecurePasswordStorage.BusinessLogic.Library.Controllers;
using System;

namespace Presentation.Console
{
    internal class Application
    {
        #region Private Fields

        private string _username;

        private string _password;

        private IUserController _userController;

        #endregion

        #region Constructors

        public Application()
        {
            _userController = new UserController();
        }

        #endregion

        #region Public Methods

        public void Run()
        {
            PrintMainMenu();
            EvalueateInput(ReadSelectInput());
        }

        #endregion

        #region Private Methods

        private void PrintMainMenu()
        {
            System.Console.Clear();
            System.Console.WriteLine("Secure Password Storage\n");
            System.Console.WriteLine("[1] Register User");
            System.Console.WriteLine("[2] Login User");
            System.Console.WriteLine("[0] Exit Application\n");
        }

        private ConsoleKeyInfo ReadSelectInput()
        {
            System.Console.Write("\nSELECT: ");

            return System.Console.ReadKey();
        }

        private void EvalueateInput(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    break;
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    PromtUser("Register User");
                    _userController.RegisterUser(_username, _password);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    PromtUser("Login");
                    if (_userController.AuthenticateUser(_username, _password))
                    {
                        WriteSystemMessageToConsole("You are now logged in");
                    }
                    else
                    {
                        WriteSystemMessageToConsole("Your username or password was wrong, try again");
                    }
                    break;
            }
        }

        private void PromtUser(string title)
        {
            System.Console.Clear();
            System.Console.WriteLine($"{title}\n");

            System.Console.Write("Username: ");
            _username = System.Console.ReadLine();

            System.Console.Write("Password: ");
            _password = System.Console.ReadLine();
        }

        private void WriteSystemMessageToConsole(string systemMessage)
        {
            System.Console.Clear();
            System.Console.WriteLine($"{systemMessage}\n");

            System.Console.Write("Press [ENTER] to continue");
            System.Console.ReadLine();
        }

        #endregion
    }
}
