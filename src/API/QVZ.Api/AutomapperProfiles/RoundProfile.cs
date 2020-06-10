using AutoMapper;
using QVZ.Api.Models;
using QVZ.DAL.Entities.Quizes;

namespace QVZ.Api.AutomapperProfiles
{
	public class RoundProfile : Profile
	{
		public RoundProfile()
		{
			this.CreateMap<Round, RoundModel>()
				.ForMember(m => m.Name, o => o.MapFrom(e => e.Name))
				.ForMember(m => m.SortOrder, o => o.MapFrom(e => e.SortOrder))
				.ForMember(m => m.QuizId, o => o.MapFrom(m => m.Quiz.Guid))
				.ReverseMap()
				.ForMember(m => m.QuizId, o => o.Ignore())
				.ForMember(m => m.Quiz, o => o.Ignore());
		}
	}
}
