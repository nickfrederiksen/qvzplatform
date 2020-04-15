using AutoMapper;
using QVZ.Api.Admin.Models;
using QVZ.DAL.Entities;

namespace QVZ.Api.Admin.AutomapperProfiles
{
	public class DashboardPanelTypeProfile : Profile
	{
		public DashboardPanelTypeProfile()
		{
			this.CreateMap<DashboardPanelType, DashboardPanelTypeModel>()
				.ForMember(m => m.Id, o => o.MapFrom(m => m.Guid))
				.ForMember(m => m.UpdatedDate, o => o.MapFrom(m => m.UpdatedDate))
				.ForMember(m => m.CreatedDate, o => o.MapFrom(m => m.CreatedDate))
				.ForMember(m => m.Name, o => o.MapFrom(m => m.Name))

				.ReverseMap()

				.ForMember(m => m.Id, o => o.Ignore())
				.ForMember(m => m.Guid, o => o.Ignore())
				.ForMember(m => m.UpdatedDate, o => o.Ignore())
				.ForMember(m => m.CreatedDate, o => o.Ignore());
		}
	}
}
