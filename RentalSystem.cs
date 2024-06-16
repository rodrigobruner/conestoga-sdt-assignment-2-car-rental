class RentalSystem{
    ReservationList reservationList = new ReservationList();

    public void Core()
    {
        addSample();
        UI.SystemHeader();
        int option = 0;

        do{
            option = OptionsMenu();

            switch (option)
            {
                case 1:
                    CreateReservation();
                    break;
                case 2:
                    ListAllReservations();
                    break;
                case 3:
                    ClearAllReservations();
                    break;
                default:
                    UI.ShowErrorMessages("System is closing...");
                    break;
            }
        UI.ShowInfoMessages("\n===========================================\n");
        }while(option != 4);
        
    }

    public int OptionsMenu(){
        UI.ShowInfoMessages("See the options below:\n");
        Console.WriteLine("1. Create a reservation");
        Console.WriteLine("2. List all Reservations");
        Console.WriteLine("3. Clear All Reservations");
        Console.WriteLine("4. Exit the program");
        int option = UI.IntField("Choose an option:");
        return option;
    }
    
    public void CreateReservation(){
        //Set default services
        ServiceList services = new ServiceList();
        services.SetDefaultServices();

        UI.ShowInfoMessages("Setep 1 - Enter customer information");

        //Custumer info
        string customerID = UI.CustumerIDField("Enter your customer ID:");
        string name = UI.textField("Enter your name:");
        string phone = UI.PhoneField("Enter your phone number:");
        int type = UI.IntField("Enter your customer type (0: Regular, 1: Premium, 2: VIP):",0,3);

        //Start new reservation
        Reservation reservation = new Reservation( 
            new Customer(customerID, name, phone, type)
        );

        // Get car info
        UI.ShowInfoMessages("Step 2 - The company offers the following car rental services to all customers:");
        services.printByServices(ServiceType.Rental);
        int carType = UI.IntField("Enter the number of the type of car you want to rent",1,3);
        reservation.addService(services.getByID(carType));

        //Get aditional services
        List<Service> aditionalServices = services.getByServices(ServiceType.Addtional);
        foreach(Service service in aditionalServices){
            bool answer = UI.YesNoField($"Do you want to include {service.name}  for just {service.price} ?");
            if(answer){
                reservation.addService(service);
            }
        }

        //Add reservation to the list
        reservationList.Create(reservation);
        UI.ShowSuccessMessages("Reservation created successfully!");
    }

    public void ListAllReservations(){
        UI.ShowInfoMessages("List of all reservations:\n");
        reservationList.List();
    }

    public void ClearAllReservations(){
        reservationList.Clear();
        UI.ShowSuccessMessages("All reservations cleared!");
    }


    public void addSample(){

        //Set default services
        ServiceList services = new ServiceList();
        services.SetDefaultServices();

        //Start new reservation
        Reservation reservation1 = new Reservation(new Customer("BRN001", "Rodrigo Bruner", "(226) 883-1828", 0));
        reservation1.addService(services.getByID(1));
        reservation1.addService(services.getByID(4));
        reservationList.Create(reservation1);

        Reservation reservation2 = new Reservation(new Customer("BRN002", "Benjamin Bruner", "(226) 883-1829", 1));
        reservation2.addService(services.getByID(2));
        reservationList.Create(reservation2);

        Reservation reservation3 = new Reservation(new Customer("BRN003", "Fernanda Kargel", "(226) 883-8888", 2));
        reservation3.addService(services.getByID(3));
        reservation3.addService(services.getByID(4));
        reservation3.addService(services.getByID(5));
        reservation3.addService(services.getByID(6));
        reservationList.Create(reservation3);
    }


}