using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Technology_Tp1_React.General;

namespace technology_tp1.Models
{
    /// <summary>
    /// Category for a MenuItem
    /// 
    /// <see cref="MenuItem"/>
    /// </summary>
    public enum Category { Pizza, Drink, Dessert, Other }

    /// <summary>
    /// Class that handle the menuitem data model
    /// </summary>
    public class MenuItem : IEntity
    {
        public MenuItem()
        {
            CreatedOn = DateTime.Now;
            UpdatedOn = null;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int ImageId { get; set; }

        [Required]
        public string Description { get; set; }

        public ItemImage Image { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public Category Category { get; set; }
    }
}
