using System.ComponentModel.DataAnnotations;

namespace Discord_API.Data
{
    public class AdminPanelUsers
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }


    }
}
