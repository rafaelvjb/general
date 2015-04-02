using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagMyCoins.Application.ViewModels;
using TagMyCoins.Domain.Entities;

namespace TagMyCoins.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Tag, TagViewModel>();
            Mapper.CreateMap<Entry, EntryViewModel>();
        }

    }
}
