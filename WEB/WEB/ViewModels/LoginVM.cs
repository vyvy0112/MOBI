using System.ComponentModel.DataAnnotations;

namespace WEB.ViewModels
{
    public class LoginVM
    {

        [Required(ErrorMessage = "yêu cầu email")]
        [EmailAddress]
        public string Email { get; set; }



		[Required(ErrorMessage = "yêu cầu pass")]
        [DataType(DataType.Password)]
		public string Password { get; set; }


        [Display(Name ="Remeber me?")]
        public bool RememberMe { get; set; }

    }
}
