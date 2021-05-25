namespace EFCore
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [StringLength(50)]
        public string ProductName { get; set; }
        [StringLength(50)]
        public string Provider { get; set; }
        
        public void PrintInfo() => Console.WriteLine($"{ProductId} - {ProductName} - {Provider}");
    }
}