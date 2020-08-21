using AutoMapper;
using QVZ.Api.Models;
using QVZ.DAL.Entities.Quizes;

namespace QVZ.Api.AutomapperProfiles
{
	internal class QuestionTypeProfile : Profile
	{
		public QuestionTypeProfile()
		{
			this.CreateMap<QuestionType, QuestionTypeModel>()
				.ForMember(m => m.Name, o => o.MapFrom(m => m.Name))
				.ReverseMap();
		}
	}
}
