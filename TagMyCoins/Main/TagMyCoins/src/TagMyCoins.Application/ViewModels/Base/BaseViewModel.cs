using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagMyCoins.Application.ViewModels.Base
{
    public class BaseViewModel
    {
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }
        [ScaffoldColumn(false)]
        public Guid CreatedByUser { get; set; }
        [ScaffoldColumn(false)]
        public DateTime UpdatedDate { get; set; }
        [ScaffoldColumn(false)]
        public Guid UpdatedByUser { get; set; }
    }
}
