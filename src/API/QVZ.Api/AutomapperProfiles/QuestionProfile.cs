using AutoMapper;
using QVZ.Api.Models;
using QVZ.DAL.Entities.Quizes;

namespace QVZ.Api.AutomapperProfiles
{
	internal class QuestionProfile : Profile
	{
		public QuestionProfile()
		{
			this.CreateMap<Question, QuestionModel>()
				.ForMember(m => m.CorrectAnswer, o => o.MapFrom(e => e.CorrectAnswer))
				.ForMember(m => m.Text, o => o.MapFrom(e => e.Text))
				.ForMember(m => m.Points, o => o.MapFrom(e => e.Points))
				.ForMember(m => m.TypeId, o => o.MapFrom(e => e.Type.Guid))
				.ForMember(m => m.RoundId, o => o.MapFrom(e => e.Round.Guid))

				.IncludeAllDerived()
				.ReverseMap()
				.ForMember(m => m.RoundId, o => o.Ignore())
				.ForMember(m => m.TypeId, o => o.Ignore())
				.IncludeAllDerived();
		}
	}
}
