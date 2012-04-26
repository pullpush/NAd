
namespace NAd.UI.ViewModels
{
    public class BlogOwner
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private BlogOwner () {}

        public static BlogOwner Create(string blogName)
        {
            if (blogName == "KodefuGuru")
            {
                return new BlogOwner
                {
                    FirstName = "Chris",
                    LastName = "Eargle"
                };
            }
            if (blogName == "PlatinumBay")
            {
                return new BlogOwner
                {
                    FirstName = "Steve",
                    LastName = "Andrews"
                };
            }
            return new BlogOwner();
        }
    }
}