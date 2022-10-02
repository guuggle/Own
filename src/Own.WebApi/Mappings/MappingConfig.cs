using Mapster;
using Own.Application.Authentication.Commands.Register;
using Own.Application.Authentication.Common;
using Own.Application.Authentication.Queries.Login;
using Own.Contracts.Authentication;

namespace Own.WebApi.Mappings
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User);
        }
    }

}