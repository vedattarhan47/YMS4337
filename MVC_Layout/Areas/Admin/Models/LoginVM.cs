namespace MVC_Layout.Areas.Admin.Models
{
    public class LoginVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsPersistant { get; set; }
    }
}