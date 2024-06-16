class Reservation:IPrinteble{
    int id;
    Customer customer;
    ServiceList serviceList = new ServiceList();


    public Reservation(Customer customer){
        this.customer = customer;
    }

    public void addService(Service service){
        this.serviceList.Add(service);
    }

    public void setId(int id){
        this.id = id;
    }

    public void Print(){
        Console.WriteLine("Reservation {0}", this.id);
        this.customer.Print();
        Console.WriteLine("Car Type:");
        this.serviceList.printByServices(ServiceType.Rental);
        Console.WriteLine("Additional services:");
        this.serviceList.printByServices(ServiceType.Addtional);
    }
}