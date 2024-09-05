using AutoMapper;
using BeyondNet.AutoMapper.Library.Resolvers;
using Shouldly;

namespace BeyondNet.AutoMapper.Test
{
    [TestClass]
    public class ResolverTest
    {
        Mapper mapper = null;

        [TestInitialize]
        public void Initialize() {
            var config = new MapperConfiguration(cfg =>
                                cfg.CreateMap<Source, Destination>()
                                .ForMember(dest => dest.Total, opt =>
                                {
                                    opt.MapFrom<CustomResolver>();
                                }));

            mapper = new Mapper(config);
        }

        [TestMethod]
        public void TestResolverShouldWork()
        {
            var source = new Source
            {
                Value1 = 5,
                Value2 = 10
            };

            Destination result = mapper.Map<Source, Destination>(source);
            result.Total.ShouldBe(15);
        }

        [TestCleanup]
        public void Cleanup()
        {
            mapper = null;
        }
    }
}
