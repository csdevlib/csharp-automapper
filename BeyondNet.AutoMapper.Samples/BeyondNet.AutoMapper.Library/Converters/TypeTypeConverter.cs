using AutoMapper;
using System.Reflection;

namespace BeyondNet.AutoMapper.Library.Converters
{
    public class TypeTypeConverter : ITypeConverter<string, Type>
    {
        public Type Convert(string source, Type destination, ResolutionContext context)
        {
            return Assembly.GetExecutingAssembly().GetType(source);
        }
    }
}
