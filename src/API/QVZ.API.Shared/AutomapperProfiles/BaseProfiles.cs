using AutoMapper;
using QVZ.Api.Shared.Models;
using QVZ.DAL.Entities.Abstracts;
using QVZ.DAL.Entities.Interfaces;

namespace QVZ.Api.Shared.AutomapperProfiles
{
	public class BaseProfiles : Profile
	{
		public BaseProfiles()
		{
			this.CreateMap<Entity, EntityModel>()
				  .ForMember(m => m.Id, o => o.MapFrom(e => e.Guid))
				  .IncludeAllDerived()
				  .ReverseMap()
				  .ForMember(e => e.Guid, o => o.Ignore())
				  .ForMember(e => e.Id, o => o.Ignore())
				  .IncludeAllDerived();


			this.CreateMap<UpdateableEntity, UpdateableModel>()
				  .ForMember(m => m.CreatedDate, o => o.MapFrom(e => e.CreatedDate))
				  .ForMember(m => m.UpdatedDate, o => o.MapFrom(e => e.UpdatedDate))
				  .IncludeAllDerived()
				  .ReverseMap()
				  .ForMember(e => e.CreatedDate, o => o.Ignore())
				  .ForMember(e => e.UpdatedDate, o => o.Ignore())
				  .IncludeAllDerived();


			this.CreateMap<UserManagedEntity, UserManagedModel>()
				  .ForMember(m => m.CreatedById, o => o.MapFrom(e => e.CreatedBy.Guid))
				  .ForMember(m => m.UpdatedById, o => o.MapFrom(e => e.UpdatedBy.Guid))
				  .IncludeAllDerived()
				  .ReverseMap()
				  .ForMember(e => e.CreatedById, o => o.Ignore())
				  .ForMember(e => e.UpdatedById, o => o.Ignore())
				  .ForMember(e => e.CreatedBy, o => o.Ignore())
				  .ForMember(e => e.UpdatedBy, o => o.Ignore())
				  .IncludeAllDerived();

			this.CreateMap<IUserOwned, IUserOwnedModel>()
				  .ForMember(m => m.UserId, o => o.MapFrom(e => e.User.Guid))
				  .IncludeAllDerived()
				  .ReverseMap()
				  .ForMember(e => e.User, o => o.Ignore())
				  .ForMember(e => e.UserId, o => o.Ignore())
				  .IncludeAllDerived();
		}
	}
}
