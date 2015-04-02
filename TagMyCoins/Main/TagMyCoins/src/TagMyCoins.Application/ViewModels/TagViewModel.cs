using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TagMyCoins.Application.ViewModels.Base;

namespace TagMyCoins.Application.ViewModels
{
    public class TagViewModel : BaseViewModel
    {
        public TagViewModel()
        {
            TagId = Guid.NewGuid();
        }

        [Key]
        public Guid TagId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Name { get; set; }
                
        public Guid ParentTagId { get; set; }
        public virtual TagViewModel ParentTag { get; set; }
    }
}
