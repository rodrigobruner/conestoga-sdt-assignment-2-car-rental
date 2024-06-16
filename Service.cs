public enum ServiceType{
    Rental,
    Addtional
}

class Service:IPrinteble{
    public int id;
    public string name;

    public double price;

    public ServiceType type;

    public Service(int id, string name, double price, ServiceType type){
        this.id = id;
        this.name = name;
        this.price = price;
        this.type = type;
    }

    public void Print(){
        Console.WriteLine($"{id} - {name} - ${price}/day");
    }
}