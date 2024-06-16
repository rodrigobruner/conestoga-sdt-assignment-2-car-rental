using System.Transactions;

class ServiceList{
    private List<Service> services = new List<Service>();

    public void Add(Service service){
        this.services.Add(service);
    }


    public void printByServices(ServiceType type){
        foreach(Service service in services){
            if(service.type == type){
                service.Print();
            }
        }
    }

    public List<Service> getByServices(ServiceType type){
        List<Service> result = new List<Service>();
        foreach(Service service in services){
            if(service.type == type){
                result.Add(service);
            }
        }
        return result;
    }

    public Service getByID(int id){
        List<Service> result = new List<Service>();
        foreach(Service service in services){
            if(service.id == id){
                return service;
            }
        }
        return new Service(0,"not found",0.0,ServiceType.Addtional);
    }

    
    public void SetDefaultServices(){
        //Add Retal servicess
        services.Add(new Service(1, "Economy Car Rental", 29.99, ServiceType.Rental));
        services.Add(new Service(2, "Standard Car Rental", 49.99, ServiceType.Rental));
        services.Add(new Service(3, "Luxury Car Rental", 79.99, ServiceType.Rental));

        //Add additional services
        services.Add(new AddtionalService(4, "GPS Navigation", 4.99));
        services.Add(new AddtionalService(5, "Child Car Seat", 14.99));
        services.Add(new AddtionalService(6, "Chauffeur Service", 99.99));
    }
}