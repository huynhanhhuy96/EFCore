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

        [Required]
        [StringLength(50)]
        [Column("Tensanpham", TypeName = "ntext")]
        public string ProductName { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int CateId { get; set; }
        // Reference Navigation
        // Foreign key
        [ForeignKey("CateId")]
        // [Required]
        public virtual Category Category { get; set; } // FK -> PK CategoryId

        public int? CateId2 { get; set; }
        [ForeignKey("CateId2")]
        [InverseProperty("Products")]
        public virtual Category Category2 { get; set; }
        
        public void PrintInfo() => Console.WriteLine($"{ProductId} - {ProductName} - {Price} - {CateId}");
    }
}

/*
    Table ("TableName")
    [Key] -> Primary Key (PK)
    [Required] -> not null
    [StringLength(50)] -> string - nverchar
    [Column("Tensanpham", TypeName = "ntext")]
    [ForeignKey("CateId")]

    Reference Navigation -> Foreign key (1 - nhieu)
    Collect Navigation -> (Khong tao ra Foreign key)

    InverseProperty
*/