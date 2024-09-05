using AutoMapper;

namespace BeyondNet.AutoMapper.Library.Resolvers
{
    public class MultBy2Resolver : IValueResolver<object, object, int>
    {
        public int Resolve(object source, object dest, int destMember, ResolutionContext context)
        {
            return destMember * 2;
        }
    }
}
