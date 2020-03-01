namespace EFarmer.pk.ViewModels.BlogsViewModels
{
    public class BlogPostViewModel
    {
        public int Id { get; set; }
        public string PostedDateTime { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Picture { get; set; }
    }
}