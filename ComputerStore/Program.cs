//  ------------------------------	
// Project 1
// © Any Ruiz  https://github.com/anyruizd/ooo-project
// Written by: Any Ruiz 2230023
//  ------------------------------

class Program {
    static void Main(string[] args) {
        Console.WriteLine("**********************************************************************");
        Console.WriteLine("            Welcome to Computer Store Management System!");
        Console.WriteLine("**********************************************************************");
        Console.WriteLine();
        Console.Write("Please enter the maximum number of computers: ");
        int maxComputers = Convert.ToInt32(Console.ReadLine());
        Computer[] inventory = new Computer[maxComputers];

        Console.WriteLine();
        string option;
        do {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine(" What do you want to do? ");
            Console.WriteLine("    1 -> Enter new computers (password required) ");
            Console.WriteLine("    2 -> Change information of a computer (password required) ");
            Console.WriteLine("    3 -> Display all computers by a specific brand ");
            Console.WriteLine("    4 -> Display all computers by a certain price ");
            Console.WriteLine("    5 -> Quit");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.Write("Your option: ");
            option = Console.ReadLine() ?? "";

            switch (option){
                case "1":
                    Console.WriteLine("Option 1 selected");
                    break;
                case "2":
                    Console.WriteLine("Option 2 selected");
                    break;
                case "3":
                    Console.WriteLine("Option 3 selected");
                    break;
                case "4":
                    Console.WriteLine("Option 4 selected");
                    break;
                case "5":
                    Console.WriteLine("Option 5 selected");
                    break;
                default:
                    break;
            }
        } while(option != "5");
    }
}