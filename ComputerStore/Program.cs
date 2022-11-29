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
        string message = "Please enter the max amount of computers you want to have in your inventory";
        int maxComputers = getInteger("Inventory", message);

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

                    bool validPwd = validatePassword();

                    if(validPwd) {
                        message = "How many computers do you want to enter?: ";
                        int computersToEnter = getInteger("Computer", message);
                        if(computersToEnter > maxComputers) {
                            Console.WriteLine();
                            Console.WriteLine($"*** ERROR *** You can only enter {maxComputers} computers.");
                            Console.WriteLine();
                        } else {
                            for (int i = 0; i < computersToEnter; i++){
                                Console.WriteLine();
                                Console.WriteLine("Enter computer " + (i+1) + " information:");
                                Console.WriteLine();
                                inventory[i] = addComputer();
                                maxComputers--;
                            }

                            Console.WriteLine();
                            Console.WriteLine("*** Computers succesfully added! ***");
                            Console.WriteLine();
                        }
                    }
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
                    Console.WriteLine();
                    Console.WriteLine("*** ERROR *** Invalid input! Please try again!");
                    Console.WriteLine();
                    break;
            }
        } while(option != "5");

    }

    static Boolean validatePassword() {
        int tries = 0;
        string password;
        do {
            Console.Write("Please enter the password: ");
            password = Console.ReadLine() ?? "";
            if(password != "password") {
                Console.WriteLine();
                Console.WriteLine("*** ERROR *** Incorrect password!");
                Console.WriteLine();
                tries++;
            }
        } while (password != "password" && tries < 3);

        if(password == "password") {
            Console.WriteLine();
            Console.WriteLine("*** Credentials are valid!  ***");
            Console.WriteLine();
            return true;
        } else {
            Console.WriteLine();
            Console.WriteLine("*** ERROR *** You have entered the password incorrectly 3 times.");
            Console.WriteLine();
            return false;
        }
    }

    static Computer addComputer() {
        Console.Write("-> Brand: ");
        string brand = Console.ReadLine() ?? "";
        Console.Write("-> Model: ");
        string model = Console.ReadLine() ?? "";
        string message = "-> Serial Number: ";
        long serialNumber = getLong("Serial number", message);
        message = "-> Price: ";
        double price = getDouble("Price", message);
        return new Computer(brand, model, serialNumber, price);
    }

    static int getInteger(string element, string message){
        int number = -1;

        do {
            Console.Write(message);
            bool isValid = Int32.TryParse(Console.ReadLine(), out number);
            if (!isValid || number < 1){
                Console.WriteLine();
                Console.WriteLine($"*** ERROR *** Invalid input! {element} should be an integer bigger than 0.");
                Console.WriteLine();
            }

        } while (number < 1);

        return number;
    }

    static long getLong(string element, string message){
        long number = -1;

        do {
            Console.Write(message);
            bool isValid = Int64.TryParse(Console.ReadLine(), out number);
            if (!isValid || number < 1){
                Console.WriteLine();
                Console.WriteLine($"*** ERROR *** Invalid input! {element} should be an integer bigger than 0.");
                Console.WriteLine();
            }

        } while (number < 1);

        return number;
    }

    static double getDouble(string element, string message){
        double number = -1;

        do {
            Console.Write(message);
            bool isValid = Double.TryParse(Console.ReadLine(), out number);
            if (!isValid || number < 1){
                Console.WriteLine();
                Console.WriteLine($"*** ERROR *** Invalid input! {element} should be a double bigger than 0.");
                Console.WriteLine();
            }

        } while (number < 1);

        return number;
    }
}
