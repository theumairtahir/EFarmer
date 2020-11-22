namespace EFarmer.pk.Areas.Admin.Models
{
    public class UserViewModel
    {
    }
    public class UserListingModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ActionButtons { get; set; }
        public long Id { get; internal set; }
    }
}
