using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB.ViewModels
{
	public class RegisterVM
	{
		//public int UserId { get; set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
		public int UserId { get; set; }


		[Required(ErrorMessage = "UserName không được để trống")]
		public string UserName { get; set; } = null!;



		[Required(ErrorMessage = "Email không được để trống")]
		[EmailAddress(ErrorMessage = "Email không hợp lệ")]
		public string Email { get; set; } = null!;




		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Mật khẩu không được để trống")]
		public string Password { get; set; } = null!;
	}
}
