using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQ.Santos.Ngo.Beertap.Model;
using IQ.Santos.Ngo.Beertap.Persistence;
using IQ.Santos.Ngo.Beertap.WebApi.Extension;
namespace IQ.Santos.Ngo.Beertap.WebApi.Infrastructure
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<KegData, Keg>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.KegId))            
                ;

            AutoMapper.Mapper.CreateMap<TapData, BeerTap>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.TapId))
                .ForMember(dest => dest.OfficeId, opts => opts.MapFrom(src => src.OfficeName))  
                .AfterMap((data, tap) => tap.KegStatus = data.ToKegLevel() )                                           
                ;

            AutoMapper.Mapper.CreateMap<OfficeData, Office>()
                .ForMember(dest=>dest.Id,opts=>opts.MapFrom(src=> src.Name))                
                .AfterMap((data, office) => office.BeerTaps = (from d in data.Taps
                    select new BeerTap {Id = d.TapId, KegId = d.KegId, OfficeId = d.OfficeName, KegStatus = d.ToKegLevel() })                   
                    .ToList());






        }
    }
}