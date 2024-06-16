class ReservationList{
    List<Reservation>  reservations = new List<Reservation>();

    int count = 0;

    public void Create(Reservation reservation){
        this.count++;
        reservation.setId(this.count);
        this.reservations.Add(reservation);
    }

    public void List(){
        if(reservations.Count > 0){
            foreach(Reservation reservation in reservations){
                reservation.Print();
                UI.ShowQuestion("-------------------------------------------\n");
            }
        } else {
            UI.ShowErrorMessages("No reservations in the system");
        }
    }

    public void Clear(){
        reservations.Clear();
    }
}