using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagMyCoins.Application.ViewModels.Base;

namespace TagMyCoins.Application.ViewModels
{
    public class EntryViewModel : BaseViewModel
    {
        public EntryViewModel()
        {
            EntryId = Guid.NewGuid();
        }

        [Key]
        public Guid EntryId { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "2", "999999999999")]
        [Required(ErrorMessage = "Preencha um valor")]
        public decimal Amount { get; set; }

        [Display(Name = "Data do Pagamento")]
	    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
	    [DataType(DataType.Date, ErrorMessage="Data em formato inválido")]
        public DateTime EntryDate { get; set; }

        //public EnumTypeTransaction TypeTransaction { get; set; }

        [DisplayName("Anotações")]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Notes { get; set; }

        ////public Guid UserId { get; set; } --> verificar quando incluir o Identity
        //public Guid GeoPositionId { get; set; }
        //public Guid ScanBillId { get; set; }
        //public Guid RepetitionId { get; set; }
        //public Guid ReminderId { get; set; }

        ////public virtual User User { get; set; } --> verificar quando incluir o Identity
        //public virtual GeoPositionViewModel GeoPosition { get; set; }
        //public virtual ScanBillViewModel ScanBill { get; set; }
        //public virtual RepetitionViewModel Repetition { get; set; }
        //public virtual ReminderViewModel Reminder { get; set; }
    }
}
