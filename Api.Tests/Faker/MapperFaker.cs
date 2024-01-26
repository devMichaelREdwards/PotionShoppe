using AutoMapper;
using Setup;

namespace Faker;

public static class MapperFaker
{
    public static IMapper MockMapper()
    {
        MappingProfile myProfile = new();
        MapperConfiguration configuration = new(cfg => cfg.AddProfile(myProfile));
        return new Mapper(configuration);
    }
}
