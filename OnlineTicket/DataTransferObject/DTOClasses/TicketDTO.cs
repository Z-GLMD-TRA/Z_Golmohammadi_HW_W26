using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses
{
    public class TicketDTO : BaseDTO<Guid>
    {
        [Required(ErrorMessage = "درج مبدا الزامی است")]
        [Display(Name = "مبدا")]
        public string OriginName { get; set; }

        [Required(ErrorMessage = "درج مقصد الزامی است")]
        [Display(Name = "مقصد")]
        public string DestinationName { get; set; }

        [Required(ErrorMessage = "درج تعداد بلیط الزامی است")]
        [Display(Name = "تعداد بلیط")]
        public int TicketCount { get; set; }

        [Required(ErrorMessage = "درج شناسه دسته الزامی است")]
        [Display(Name = "شناسه دسته")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "درج تاریخ سفر الزامی است")]
        [Display(Name = "تاریخ سفر")]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "درج قیمت الزامی است")]
        [Range(0, double.MaxValue, ErrorMessage = "قیمت باید بزرگتر از صفر باشد")]
        [Display(Name = "قیمت")]
        public decimal Price { get; set; }
    }
}
