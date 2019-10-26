using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Technology_Tp1_React.General.Repository;

namespace technology_tp1.Models
{
    /// <summary>
    /// Class that handle the delivery data model
    /// </summary>
    public class DeliveryMan : IEntity
    {
        public DeliveryMan(){
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        public bool IsEmployed { get; set; }
        public bool IsDeactivated { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
