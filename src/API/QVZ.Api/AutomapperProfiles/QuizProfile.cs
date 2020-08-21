using AutoMapper;
using QVZ.Api.Models;
using QVZ.DAL.Entities.Quizes;

namespace QVZ.Api.AutomapperProfiles
{
	internal class QuizProfile : Profile
	{
		public QuizProfile()
		{
			this.CreateMap<Quiz, QuizModel>()
				.ForMember(m => m.Date, o => o.MapFrom(e => e.Date))
				.ForMember(m => m.Name, o => o.MapFrom(e => e.Name))
				.ReverseMap();
		}
	}
}
