using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WEB.ViewModels
{
	public class AppUserVM: IdentityUser
	{
		public int UserId { get; set; }

		//[Required(ErrorMessage ="Username chỉ chứa chữ và số")]
		public string UserName { get; set; } = null!;


		//[Required(ErrorMessage = "Email không được để trống"),EmailAddress]
		public string Email { get; set; } = null!;


		// datatype password để mã hóa mật khẩu
		//[DataType(DataType.Password),Required(ErrorMessage = "Mật khẩu không được để trống")]
		public string Password { get; set; } = null!;

		//public string? Role { get; set; }
	}
}
