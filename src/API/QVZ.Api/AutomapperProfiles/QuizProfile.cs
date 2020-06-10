using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using QVZ.Api.Models;
using QVZ.Api.Shared.Models;
using QVZ.DAL.Entities.Abstracts;
using QVZ.DAL.Entities.Interfaces;
using QVZ.DAL.Entities.Quizes;

namespace QVZ.Api.AutomapperProfiles
{
	public class QuizProfile : Profile
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
