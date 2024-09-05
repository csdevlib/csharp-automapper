using AutoMapper;
using BeyondNet.AutoMapper.Library.Converters;

namespace BeyondNet.AutoMapper.Test.Profiles
{
    public class ConverterProfile : Profile
    {
        public ConverterProfile()
        {
            CreateMap<Source, Destination>();
        }
    }
}
