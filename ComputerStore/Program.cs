using System;
using System.IO;
//  ------------------------------	
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
        int maxComputers = getInteger("Inventory", message); // verifies the input is valid
        Computer[] inventory = new Computer[maxComputers];

        Console.WriteLine();
        string option;
        /************************************ Main menu ************************************/
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
                    // enterNewComputers returns the updated value of maxComputers
                    maxComputers = enterNewComputers(maxComputers, inventory);
                    break;
                case "2":
                    // changeInformation returns the updated value of maxComputers
                    maxComputers = changeInformation(maxComputers, inventory);
                    break;
                case "3":
                    displayByBrand(inventory);
                    break;
                case "4":
                    displayByPrice(inventory);
                    break;
                case "5":
                    saveComputerList(inventory);
                    showSavedList();
                    Console.WriteLine("Leaving the application... Bye!");
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
                string message = "Enter new serial number: ";
                long newSerialNumber = getLong("Serial number", message);
                inventory[computerNumber-1].setSerialNumber(newSerialNumber);
                Console.WriteLine();
                Console.WriteLine("***  Serial number changed succesfully! ***");
                Console.WriteLine();
                inventory[computerNumber-1].showComputer();
                break;
            case "4":
                message = "Enter new price: ";
                double newPrice = getDouble("Price", message);
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

    /*
        getInteger receives an element and a message and returns an integer when it's valid,
        the element is the string that represents what we are entering: inventory, computer number,  
        the message is explaining the user what input we are expecting.
    */
    static int getInteger(string element, string message){
        int number = -1;

        do {
            Console.Write(message);
            bool isValid = Int32.TryParse(Console.ReadLine(), out number);
            if (!isValid || number < 1){ // Does not accept a number smaller than 1
                Console.WriteLine();
                Console.WriteLine($"*** ERROR *** Invalid input! {element} should be an integer bigger than 0.");
                Console.WriteLine();
            }

        } while (number < 1);

        return number;
    }

    /*
        getLong receives an element and a message and returns a long when it's valid,
        the element is the string that represents what we are entering: serial number 
        the message is explaining the user what input we are expecting.
    */
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

    /*
        getDouble receives an element and a message and returns a double when it's valid,
        the element is the string that represents what we are entering: price 
        the message is explaining the user what input we are expecting
    */
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

    /*
        enterNewComputers receives the max number of computers available and the inventory,
        and returns the updated number of max computers
    */
    static int enterNewComputers(int maxComputers, Computer [] inventory) {
        bool validPwd = false;
        validPwd = validatePassword();

        if(!validPwd) {
            return maxComputers;
        }
        string message = "How many computers do you want to enter?: ";
        int computersToEnter = getInteger("Computer", message);
        if(computersToEnter > maxComputers) { // we can no enter more computers than the max allowed
            Console.WriteLine();
            Console.WriteLine($"*** ERROR *** You can only enter {maxComputers} computers.");
            Console.WriteLine();
        } else {
            for (int i = Computer.findNumberOfCreatedComputers(); i < computersToEnter; i++){
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
        return maxComputers;
    }

    /*
        changeInformation receives the max number of computers available and the inventory,
        and returns the updated number of max computers
    */
    static int changeInformation(int maxComputers, Computer [] inventory) {
        int enteredComputers = Computer.findNumberOfCreatedComputers();
        if(enteredComputers == 0 ) { // first we validate if we have computers in the inventory
            Console.WriteLine();
            Console.WriteLine("*** ERROR *** There is no computers in the inventory! Please try adding one first.");
            Console.WriteLine();
            return maxComputers; // if there is no computers to modify, the number of maxComputers wasn't updated
        }

        bool validPwd = false;
        validPwd = validatePassword();

        if(!validPwd) { // if the password is invalid, the number of maxComputers wasn't updated
            return maxComputers;
        }

        string message = "Enter the number of the computer you wish to update: ";
        int computerNumber = getInteger("Computer", message);

        if(computerNumber > enteredComputers) { // If the computer does not exist, we give the option to the user to add a new computer
            Console.WriteLine();
            Console.WriteLine($"*** ERROR *** There is no computer with number {computerNumber}, would you like to add a new computer?");
            Console.WriteLine();
            Console.Write("Enter Y to enter a new computer, N to go back to the main menu: ");
            string choice = Console.ReadLine() ?? "";
            if(choice.ToLower() == "y") { // We accept Y or y, otherwise it returns to the main menu
                if(enteredComputers == maxComputers) { // Check if the inventory is already full
                    Console.WriteLine();
                    Console.WriteLine("*** ERROR *** You cannot enter more computers.");
                    Console.WriteLine();
                } else { // if there is space in the inventory we add the new single computer
                    Console.WriteLine();
                    Console.WriteLine($"Enter computer {enteredComputers + 1} information:");
                    Console.WriteLine();
                    inventory[enteredComputers] = addComputer();
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
        } else { // If the computer exists in the inventory
            Console.WriteLine();
            Console.WriteLine($"-------- Computer # {computerNumber} ----------");
            inventory[computerNumber-1].showComputer();
            Console.WriteLine();
            string choice = "";
            do { // ask for the information to change
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

        return maxComputers;
    }

    /*
        displayByBrand receives the inventory and shows the 
        list of computers filtered by the entered brand
    */
    static void displayByBrand(Computer [] inventory){
        int enteredComputers = Computer.findNumberOfCreatedComputers();
        if(enteredComputers == 0 ) { // if there is no computers in the inventory it gets out
            Console.WriteLine();
            Console.WriteLine("*** ERROR *** There is no computers in the inventory! Please try adding one first.");
            Console.WriteLine();
            return;
        }

        Console.Write("Enter the brand you want to search: ");
        string brand = Console.ReadLine() ?? "";
        Console.WriteLine();
        Console.WriteLine($"-------- Computers with brand {brand} ----------");
        Console.WriteLine();
        Boolean found = false;
        for (int i = 0; i < Computer.findNumberOfCreatedComputers(); i++){
            if((inventory[i].getBrand()).ToLower() == brand.ToLower()) { // filter by brand is case insensitive
                found = true;
                inventory[i].showComputer();
                Console.WriteLine();
            }
        }
        if(!found) { // If no computer with the entered brand was found
            Console.WriteLine();
            Console.WriteLine("*** ERROR *** There is no computers in the inventory with this brand! Please try again.");
            Console.WriteLine();
        }
    }

    /*
        displayByPrice receives the inventory and shows the 
        list of computers filtered by the entered price
    */
    static void displayByPrice(Computer [] inventory){
        int enteredComputers = Computer.findNumberOfCreatedComputers();
        if(enteredComputers == 0 ) { // if there is no computers in the inventory it gets out
            Console.WriteLine();
            Console.WriteLine("*** ERROR *** There is no computers in the inventory! Please try adding one first.");
            Console.WriteLine();
            return;
        }

        string message = "Enter the price you want to search: ";
        double price = getDouble("Price", message); // verifies the price entered is valid
        Console.WriteLine();
        Console.WriteLine($"-------- Computers with price {price} ----------");
        Console.WriteLine();
        Boolean found = false;
        for (int i = 0; i < Computer.findNumberOfCreatedComputers(); i++){
            if(inventory[i].getPrice() == price) {
                found = true;
                inventory[i].showComputer();
                Console.WriteLine();
            }
        }

        if(!found) {// If no computer with the entered price was found
            Console.WriteLine();
            Console.WriteLine("*** ERROR *** There is no computers in the inventory with this price! Please try again.");
            Console.WriteLine();
        }
    }

    /*
        saveComputerList receives the inventory and saves the list of computers
        into the file specified in the path
    */
    static void saveComputerList(Computer[] inventory){
        string myFilePath = @"./computer-list.txt";
        StreamWriter sw = new StreamWriter(myFilePath);
        for(int i = 0; i < Computer.findNumberOfCreatedComputers(); i++) {
            sw.WriteLine($"-------- Computer # {i+1} ----------");
            sw.WriteLine($"Brand: {inventory[i].getBrand()}");
            sw.WriteLine($"Model: {inventory[i].getModel()}");
            sw.WriteLine($"Serial Number: {inventory[i].getSerialNumber()}");
            sw.WriteLine($"Price: {inventory[i].getPrice()}");
        }
        sw.Close();
    }

    /*
        showSavedList reads and shows into the console the list of computers saved into the file specified in the path
    */
    static void showSavedList() {
        string myFilePath = @"./computer-list.txt"; 
        string[] lines = File.ReadAllLines(myFilePath);
        
        Console.WriteLine();
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }
}
