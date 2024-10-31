using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses
{
    public class UserDTO : BaseDTO<Guid>
    {
        /// <summary>
        /// First name of user
        /// </summary>
        [Required(ErrorMessage = "درج نام الزامی است")]
        [Display(Name = "نام")]
        public string FirstName { get; set; } = string.Empty;
        /// <summary>
        /// Last name of user
        /// </summary>
        [Required(ErrorMessage = "درج نام خانوادگی الزامی است")]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; } = string.Empty;
        /// <summary>
        /// Email of user
        /// </summary>
        [Required(ErrorMessage = "درج ایمیل الزامی است")]
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "فرمت آدرس ایمیل وارد شده نامعتبر است")]
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// Phone of user
        /// </summary>
        [Required(ErrorMessage = "درج شماره موبایل الزامی است")]
        [Display(Name = "شماره موبایل")]
        public string Phone { get; set; } = string.Empty;
        /// <summary>
        /// User's birth date
        /// </summary>
        [Required(ErrorMessage = "درج تاریخ تولد الزامی است")]
        [Display(Name = "تاریخ تولد")]
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Check this user is enable or not
        /// </summary>
        //public bool IsActived { get; set; }
        /// <summary>
        /// UserName of user
        /// </summary>
        //public string UserName { get; set; } = string.Empty;
        /// <summary>
        /// Password of user
        /// </summary>

        [Required(ErrorMessage = "درج کلمه عبور الزامی است")]
        [Display(Name = "کلمه عبور")]
        [StringLength(100, ErrorMessage = "کلمه عبور حداقل باید 6 حرف باشد", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        /// <summary>
        /// Confirm password of user
        /// </summary>
        [Required(ErrorMessage = "درج تکرار کلمه عبور الزامی است")]
        [Display(Name = "تکرار کلمه عبور")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه عبور و تکرار آن باید یکی باشد")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
