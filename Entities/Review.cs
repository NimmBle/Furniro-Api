namespace furniro_server.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Review : BaseEntity
    {
        [Required]
        [Range(1, 5)]
        public int Value { get; set; }

        [MinLength(2)]
        [MaxLength(256)]
        public string Comment { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}