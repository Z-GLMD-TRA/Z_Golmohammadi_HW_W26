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

        /// <summary>
        /// ID of the category associated with the ticket.
        /// </summary>
        [Required(ErrorMessage = "درج شناسه دسته الزامی است")]
        [Display(Name = "شناسه دسته")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Seat number assigned for the ticket.
        /// </summary>
        [Required(ErrorMessage = "درج شماره صندلی الزامی است")]
        [Display(Name = "شماره صندلی")]
        public int SeatNumber { get; set; }
        /// <summary>
        /// The date and time of the trip or event.
        /// </summary>
        [Required(ErrorMessage = "درج تاریخ سفر الزامی است")]
        [Display(Name = "تاریخ سفر")]
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// The return date for the trip, if applicable.
        /// </summary>
        [Display(Name = "تاریخ بازگشت")]
        public DateTime? ReturnDate { get; set; } // Nullable for one-way tickets

        /// <summary>
        /// Price of the ticket.
        /// </summary>
        [Required(ErrorMessage = "درج قیمت الزامی است")]
        [Range(0, double.MaxValue, ErrorMessage = "قیمت باید بزرگتر از صفر باشد")]
        [Display(Name = "قیمت")]
        public decimal Price { get; set; }


        /// <summary>
        /// Name of the passenger associated with the ticket.
        /// </summary>
        [Required(ErrorMessage = "درج نام مسافر الزامی است")]
        [Display(Name = "نام مسافر")]
        public string PassengerName { get; set; } = string.Empty;

    }
}
