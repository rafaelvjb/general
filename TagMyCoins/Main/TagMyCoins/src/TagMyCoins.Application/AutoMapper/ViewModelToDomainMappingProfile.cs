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
    public class ViewModelToDomainMappingProfile :Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<TagViewModel, Tag>();
            Mapper.CreateMap<EntryViewModel, Entry>();
        }
    }
}
