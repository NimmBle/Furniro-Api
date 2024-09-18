namespace furniro_server.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } 
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}