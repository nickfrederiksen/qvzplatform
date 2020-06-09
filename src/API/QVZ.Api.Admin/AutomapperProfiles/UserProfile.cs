using AutoMapper;
using QVZ.Api.Admin.Models;
using QVZ.DAL.Entities;

namespace QVZ.Api.Admin.AutomapperProfiles
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			this.CreateMap<User, UserModel>()
				.ForMember(m => m.Id, o => o.MapFrom(m => m.Guid))
				.ForMember(m => m.ObjectIdentifier, o => o.MapFrom(m => m.ObjectId));
		}
	}
}
