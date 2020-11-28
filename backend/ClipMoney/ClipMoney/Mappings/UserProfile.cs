using AutoMapper;
using ClipMoney.Entities;
using ClipMoney.Models;

namespace ClipMoney.Mappings
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, Usuario>()
                .ForMember(d => d.IdUsuario, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.NombreUsuario, opt => opt.MapFrom(s => s.Firstname))
                .ForMember(d => d.Mail, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.Apellido, opt => opt.MapFrom(s => s.Lastname))
                .ForMember(d => d.Cbu, opt => opt.MapFrom(s => s.Cbu))
                .ForMember(d => d.Contraseña, opt => opt.MapFrom(s => s.Password));

            CreateMap<Usuario, UserModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.IdUsuario))
                .ForMember(d => d.Firstname, opt => opt.MapFrom(s => s.NombreUsuario))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Mail))
                .ForMember(d => d.Lastname, opt => opt.MapFrom(s => s.Apellido))
                .ForMember(d => d.Cbu, opt => opt.MapFrom(s => s.Cbu))
                .ForMember(d => d.Password, opt => opt.MapFrom(s => s.Contraseña));
        }
    }
}
