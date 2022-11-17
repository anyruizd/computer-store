//  ------------------------------	
// Project 1
// © Any Ruiz  https://github.com/anyruizd/ooo-project
// Written by: Any Ruiz 2230023
//  ------------------------------

class Program {
    static void Main(string[] args) {
        Computer c1 = new Computer("apple", "macbook pro 13 inches", 1000001, 2500);
        Console.WriteLine(c1.findNumberOfCreatedComputers());
        Computer c2 = new Computer("apple", "macbook pro 13 inches", 1000002, 2500);
        Console.WriteLine(c2.findNumberOfCreatedComputers());
        c1.showComputer();
        c2.showComputer();
        string equal = c1.isEqualTo(c2) ? "" : "not ";
        Console.WriteLine($"V1 is {equal}equal to V2");
    }
}