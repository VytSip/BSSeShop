using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Data
{
    public class Cart : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public virtual ICollection<ProductCart> ProductCarts { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        public string UserId { get; set; }

        public bool Active { get; set; }

        public Cart()
        {
            ProductCarts = new List<ProductCart>();
        }
    }
}
