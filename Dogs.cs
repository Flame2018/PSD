using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ken_PS1.Data
{
    public class Dogs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID { get; set; }

        [Display(Name = "Dog Name")]
        public string Dname { get; set; }

        public string Breed { get; set; }

        [Display(Name = "Store ID")]
        public int PSID { get; set; }

        [ForeignKey("PSID")]
        public PetStore PsID { get; set; }
    }
}
