using AutoMapper;
using BeyondNet.AutoMapper.Library.Converters;
using BeyondNet.AutoMapper.Test.Profiles;
using Shouldly;

namespace BeyondNet.AutoMapper.Test
{
    [TestClass]
    public class ConverterTest
    {
        Mapper mapper = null;



        [TestInitialize]
        public void Setup()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ConverterProfile>();
                cfg.CreateMap<string, int>().ConvertUsing(s => Convert.ToInt32(s));
                cfg.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());
                cfg.CreateMap<string, Type>().ConvertUsing<TypeTypeConverter>();
                cfg.CreateMap<Source, Destination>();
            });

            mapper = new Mapper(config);
        }

        [TestCleanup]
        public void Cleanup()
        {
            mapper = null;
        }

        [TestMethod]
        public void TestConverterShouldThrowAndError()
        {
            var source = new Source
            {
                Value1 = "10",
                Value2 = "2020-01-01",
                Value3 = "System.String"
            };

            Assert.ThrowsException<AutoMapperMappingException>(() => mapper.Map<Destination>(source));
        }

        [TestMethod]
        public void TestConverterShouldWork()
        {
            var source = new Source
            {
                Value1 = "5",
                Value2 = "01/01/2000",
                Value3 = "BeyondNet.AutoMapper.Library.Entities.Destination"
            };

            Destination result = mapper.Map<Source, Destination>(source);
            result.Value3.ShouldBe(typeof(Destination));
        }
    }
}
