// Copyright (c) Nick Frederiksen. All Rights Reserved.

using AutoMapper;
using QVZ.Api.Admin.Models;
using QVZ.DAL.Entities;
using QVZ.DAL.Entities.Dashboards;

namespace QVZ.Api.Admin.AutomapperProfiles
{
	public class DashboardProfile : Profile
	{
		public DashboardProfile()
		{
			this.CreateMap<Dashboard, DashboardModel>()
				.ForMember(m => m.Id, o => o.MapFrom(m => m.Guid))
				.ForMember(m => m.UpdatedDate, o => o.MapFrom(m => m.UpdatedDate))
				.ForMember(m => m.CreatedDate, o => o.MapFrom(m => m.CreatedDate))
				.ForMember(m => m.Name, o => o.MapFrom(m => m.Name))
				.ForMember(m => m.UserId, o => o.MapFrom(m => m.User.Guid))

				.ReverseMap()

				.ForMember(m => m.Id, o => o.Ignore())
				.ForMember(m => m.Guid, o => o.Ignore())
				.ForMember(m => m.UpdatedDate, o => o.Ignore())
				.ForMember(m => m.CreatedDate, o => o.Ignore())
				.ForMember(m => m.UserId, o => o.Ignore());

		}
	}
}
