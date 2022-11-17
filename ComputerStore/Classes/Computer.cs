class Computer {
    private static int computerNumber = 0;
    public string holi = "Holi";
    private string brand;
    private string model;
    private long serialNumber;
    private double price;

    public Computer() {
        brand = "";
        model = "";
        serialNumber = 0;
        price = 0;
        computerNumber++;
    }

    public Computer(string b, string m, long sn, double p) {
        brand = b;
        model = m;
        serialNumber = sn;
        price = p;
        computerNumber++;
    }

    public void setBrand(string b){
        brand = b;
    }

    public string getBrand(){
        return brand;
    }

    public void setModel(string m){
        model = m;
    }

    public string getModel(){
        return model;
    }

    public void setSerialNumber(long sn){
        if(sn < 0) {
            serialNumber = sn;
        } else {
            Console.WriteLine("Error! Serial number should not be negative");
        }
    }

    public long getSerialNumber(){
        return serialNumber;
    }

    public void setPrice(double p){
        if(p < 0) {
            price = p;
        } else {
            Console.WriteLine("Error! Price should not be negative");
        }
    }

    public double getPrice(){
        return price;
    }

    public int findNumberOfCreatedComputers () {
        return computerNumber;
    }

    public void showComputer() {
        Console.WriteLine($"-------- Computer ----------");
        Console.WriteLine($"Brand: {brand}");
        Console.WriteLine($"Model: {model}");
        Console.WriteLine($"Serial Number: {serialNumber}");
        Console.WriteLine($"Price: {price}");
        Console.WriteLine("----------------------------");
    }

    public Boolean isEqualTo(Computer c) {
        if(this.brand == c.getBrand() && this.price == c.getPrice() && this.model == c.getModel()){
            return true;
        } else {
            return false;
        }
    }
}