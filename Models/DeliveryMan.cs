using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Technology_Tp1_React.General;

namespace technology_tp1.Models
{
    public class DeliveryMan : IEntity
    {
        public DeliveryMan(){
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }

        public DeliveryMan(int id, string name, string phone, bool isEmployed)
        {
            Id = id;
            Name = name;
            Phone = phone;
            IsEmployed = isEmployed;
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool IsEmployed { get; set; }
        public bool IsDeactivated { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
