using System.Data.Common;

public enum CustomerType{
    Regular = 0,
    Premium = 1,
    VIP = 2
}


class Customer:IPrinteble{
    string id;
    string name;
    string phone;
    CustomerType type;

    public Customer(string id, string name, string phone, int type){
        this.id = id;
        this.name = name;
        this.phone = phone;
        this.type = (CustomerType) type;
        // UI.Debug($"AQUI: {name} = {(CustomerType) type}");
    }

    public void Print(){
        string protectedID = "XXX"+id.Substring(3,3);
        Console.WriteLine("Customer ID: {0}", protectedID);
        Console.WriteLine("Name: {0}", name);
        Console.WriteLine("Phone Number: {0}", phone);
        Console.WriteLine("Customer Type: {0}", type);
    }
}