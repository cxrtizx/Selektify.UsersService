namespace PresentationLayer
{
    public class UserMenu
    {
        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("#### MENU ####");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Exit");
            Console.Write("Please select an option: ");
        }

        public static void ProcessInput()
        {
            ShowMenu();
            bool exit = false;
            string? input = Console.ReadLine();
            if (input != null)
            {
                switch (input)
                {
                    case "1":
                        // Call the login service
                        Console.WriteLine("Login selected");
                        break;
                    case "2":
                        Console.WriteLine("Exiting...");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Input cannot be null. Please try again.");
            }

            if (!exit) ProcessInput();
        }
    }
}
