using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportSystem.Data.DbModels;
using TransportSystem.Data.Entities;
using TransportSystem.ViewModels;

namespace TransportSystem.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<TerminalViewModel, Terminal>().ReverseMap();
            CreateMap<Terminal, HomeViewModel>().ReverseMap();
            CreateMap<DepartingTerminal, HomeViewModel>().ReverseMap();
            CreateMap<BusesViewModel, Bus>().ReverseMap();
            CreateMap<Bus, BusSelectionViewModel>().ForMember(des => des.Terminal, opt =>opt.MapFrom(des => des.Terminal.TerminalName))
                .ForMember(des => des.DepartingTerminal, opt => opt.MapFrom(des => des.DepartingTerminal.DepartingTerminalName))
                .ReverseMap();
            CreateMap<AccountViewModel, ApplicationUser>().ReverseMap();
           

            //Mapper.CreateMap<CategoriesViewModel, Categoies>()
            //.ForMember(c => c.CategoryPositions, option => option.Ignore())
            //.ForMember(c => c.Posts, option => option.Ignore());

            //.ForMember(des => des.DepartingTerminalName, opt => opt.MapFrom(des => des.DepartingTerminalName))
            //   .ForMember(des => des.Id, opt => opt.MapFrom(scr => scr.Id))

            //CreateMap<Author, Models.AuthorsDto>()
            //    .ForMember(des => des.Name,
            //    opt => opt.MapFrom(src => $"{src.FirstName}{src.LastName}"))
            //    .ForMember(des => des.Age,
            //    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));
        }
    }
}
