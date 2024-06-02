using System.ComponentModel.DataAnnotations;

namespace SignalRUdemy.Models
{
    public class ChatRoom
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
