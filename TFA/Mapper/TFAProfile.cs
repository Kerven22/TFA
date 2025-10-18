using AutoMapper;
using TFA.Domain.UseCases.SignIn;
using TFA.Domain.UseCases.SignOn;
using TFA.Models.Requests;

namespace TFA.Mapper
{
    public class TFAProfile:Profile
    {
        public TFAProfile()
        {
            CreateMap<UserSignOn, UserSignOnCommand>();
            //.ForMember(d => d.PhoneNumber, s => s.MapFrom(u => u.PhoneNumber))
            //.ForMember(d => d.SecondName, s => s.MapFrom(u => u.SecondName))
            //.ForMember(d => d.Login, s => s.MapFrom(u => u.Login))
            //.ForMember(d => d.Email, s => s.MapFrom(u => u.Email))
            //.ForMember(d => d.Age, s => s.MapFrom(u => u.Age));

            CreateMap<UserSignIn, SignInCommand>()
                .ForMember(d=>d.Login, s=>s.MapFrom(u=>u.Login))
                .ForMember(d=>d.Password, s=>s.MapFrom(u=>u.Password)); 

        }
    }
}
