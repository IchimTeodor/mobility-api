using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHospitalizationPal.DAL.Models
{
    public partial class Department
    {
        public Department()
        {
            Encounter = new HashSet<Encounter>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string DepartmentName { get; set; }

        [InverseProperty("Department")]
        public ICollection<Encounter> Encounter { get; set; }
    }
}
