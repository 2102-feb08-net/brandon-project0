


namespace Project0.Customers
{
    public interface ICustomer
    {
        int ID { get; }

        string FirstName { get; set; }
        string LastName { get; set; } 
        string Phone { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        string State { get; set; }
    }
}
