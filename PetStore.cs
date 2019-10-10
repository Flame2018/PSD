using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ken_PS1.Data
{
    public class PetStore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PSID { get; set; }

        [Display(Name ="PetStore Name")]
        public string PSname { get; set; }

        [Display(Name ="Capacity")]
        public int PScap { get; set; }        
    }
}
