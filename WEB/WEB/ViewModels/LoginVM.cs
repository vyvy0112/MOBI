using System.ComponentModel.DataAnnotations;

namespace WEB.ViewModels
{
    public class LoginVM
    {

		[Required(ErrorMessage = "UserName không được để trống")]
		[Display(Name ="Tên Đăng Nhập")]
		public string UserName { get; set; } = null!;


		[Display(Name = "Mật Khẩu")]
		[Required(ErrorMessage = "Password không được để trống ")]
        [DataType(DataType.Password)]
		public string Password { get; set; }


   

    }
}
