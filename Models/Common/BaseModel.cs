using System.ComponentModel.DataAnnotations;

namespace furniro_server.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationDate { get; private set; } = DateTime.UtcNow;
        public DateTime LastUpdateTime { get; set; } = DateTime.UtcNow;
    }
}