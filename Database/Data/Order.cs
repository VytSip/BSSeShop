using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Data
{
    public class Order : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int Number { get; set; }

        public decimal Price { get; set; }

        public string User { get; set; }

        public Guid CartId { get; set; }

        [ForeignKey("CartId")]
        public Cart Cart { get; set; }
    }
}
