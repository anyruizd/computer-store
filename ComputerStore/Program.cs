﻿//  ------------------------------	
// Project 1
// © Any Ruiz  https://github.com/anyruizd/computer-store
// Written by: Any Ruiz 2230023
//  ------------------------------

class Program {
    static void Main(string[] args) {
        Console.WriteLine("**********************************************************************");
        Console.WriteLine("            Welcome to Computer Store Management System!");
        Console.WriteLine("**********************************************************************");
        Console.WriteLine();
        string message = "Please enter the max amount of computers you want to have in your inventory: ";
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
            
            bool validPwd = false;

            switch (option){
                case "1":
                    validPwd = validatePassword();

                    if(!validPwd) {
                        break;
                    }
                    message = "How many computers do you want to enter?: ";
                    int computersToEnter = getInteger("Computer", message);
                    if(computersToEnter > maxComputers) {
                        Console.WriteLine();
                        Console.WriteLine($"*** ERROR *** You can only enter {maxComputers} computers.");
                        Console.WriteLine();
                    } else {
                        for (int i = 0; i < computersToEnter; i++){
                            Console.WriteLine();
                            Console.WriteLine($"Enter computer {i+1} information:");
                            Console.WriteLine();
                            inventory[i] = addComputer();
                            maxComputers--;
                        }
                        Console.WriteLine();
                        Console.WriteLine("*** Computers succesfully added! ***");
                        Console.WriteLine();
                    }
                    break;
                case "2":
                    validPwd = validatePassword();

                    if(!validPwd) {
                        break;
                    }
                    int enteredComputers = Computer.findNumberOfCreatedComputers();
                    if(enteredComputers == 0 ) {
                        Console.WriteLine();
                        Console.WriteLine("*** ERROR *** There is no computers in the inventory! Please try adding one first.");
                        Console.WriteLine();
                        break;
                    }

                    message = "Which computer number do you wish to update?: ";
                    int computerNumber = getInteger("Computer", message);

                    if(computerNumber > enteredComputers) {
                        Console.WriteLine();
                        Console.WriteLine($"*** ERROR *** There is no computer with number {computerNumber}, would you like to add a new computer?");
                        Console.WriteLine();
                        Console.Write("Enter Y to enter a new computer, N to go back to the main menu: ");
                        string choice = Console.ReadLine() ?? "";
                        if(choice == "Y" || choice == "y") {
                            if(enteredComputers == maxComputers) {
                                Console.WriteLine();
                                Console.WriteLine("*** ERROR *** You cannot enter more computers.");
                                Console.WriteLine();
                            } else {
                                Console.WriteLine();
                                Console.WriteLine($"Enter computer {enteredComputers} information:");
                                Console.WriteLine();
                                inventory[enteredComputers-1] = addComputer();
                                maxComputers--;
                                Console.WriteLine();
                                Console.WriteLine("*** Computer succesfully added! ***");
                                Console.WriteLine();
                            }
                        } else {
                            Console.WriteLine();
                            Console.WriteLine("*** Going back to main menu... ***");
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                    } else {
                        Console.WriteLine();
                        Console.WriteLine($"-------- Computer # {computerNumber} ----------");
                        inventory[computerNumber-1].showComputer();
                        Console.WriteLine();
                        string choice = "";
                        do {
                            Console.WriteLine("What information would you like to change? ");
                            Console.WriteLine("    1 -> Brand");
                            Console.WriteLine("    2 -> Model");
                            Console.WriteLine("    3 -> Serial Number");
                            Console.WriteLine("    4 -> Price");
                            Console.WriteLine("    5 -> Quit");
                            Console.Write("Enter your choice: ");
                            choice = Console.ReadLine() ?? "";
                            editComputer(choice, computerNumber, inventory);
                        } while(choice != "5");
                    };
                    break;
                case "3":
                    Console.WriteLine("Option 3 selected: Display all computers by a specific brand");
                    break;
                case "4":
                    Console.WriteLine("Option 4 selected: Display all computers by a certain price");
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

    static void editComputer(string choice, int computerNumber, Computer[] inventory) {
        switch (choice){
            case "1":
                Console.Write("Enter new brand: ");
                string newBrand = Console.ReadLine() ?? "";
                inventory[computerNumber-1].setBrand(newBrand);
                Console.WriteLine();
                Console.WriteLine("*** Brand changed succesfully! ***");
                Console.WriteLine();
                inventory[computerNumber-1].showComputer();
                break;
            case "2":
                Console.Write("Enter new model: ");
                string newModel = Console.ReadLine() ?? "";
                inventory[computerNumber-1].setModel(newModel);
                Console.WriteLine();
                Console.WriteLine("*** Model changed succesfully! ***");
                Console.WriteLine();
                inventory[computerNumber-1].showComputer();
                break;
            case "3":
                Console.Write("Enter new serial number: ");
                long newSerialNumber = Convert.ToInt64(Console.ReadLine() ?? "");
                inventory[computerNumber-1].setSerialNumber(newSerialNumber);
                Console.WriteLine();
                Console.WriteLine("***  Serial number changed succesfully! ***");
                Console.WriteLine();
                inventory[computerNumber-1].showComputer();
                break;
            case "4":
                Console.Write("Enter new price: ");
                double newPrice = Convert.ToDouble(Console.ReadLine() ?? "");
                inventory[computerNumber-1].setPrice(newPrice);
                Console.WriteLine();
                Console.WriteLine("*** Price changed succesfully! ***");
                Console.WriteLine();
                inventory[computerNumber-1].showComputer();
                break;
            case "5":
                Console.WriteLine();
                Console.WriteLine("*** Going back to main menu... ***");
                Console.WriteLine();
                break;
            default:
                Console.WriteLine();
                Console.WriteLine("*** ERROR *** Invalid option.");
                Console.WriteLine();
                break;
        }
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
