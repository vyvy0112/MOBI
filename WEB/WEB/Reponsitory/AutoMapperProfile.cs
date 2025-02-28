using AutoMapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using WEB.Data;
using WEB.ViewModels;

namespace WEB.Reponsitory
{
	public class AutoMapperProfile:Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<RegisterVM, User>();
				//.ForMember(user=>user.UserName, option => option.MapFrom(RegisterVM => RegisterVM.UserName)).ReverseMap();
		}

	}
}
