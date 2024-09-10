using System.ComponentModel.DataAnnotations;

namespace furniro_server.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}