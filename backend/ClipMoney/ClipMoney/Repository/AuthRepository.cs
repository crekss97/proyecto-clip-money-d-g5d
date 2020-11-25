﻿using ClipMoney.Entities;
using ClipMoney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Repository
{
    public class AuthRepository
    {
        private readonly BilleteraVirtualContext _context;
        public AuthRepository()
        {
            _context = new BilleteraVirtualContext();
        }
        public void SignInUser(UserModel user)
        {
            var newUserDb = new Usuario();
            newUserDb.Mail = user.Email;
            newUserDb.NombreUsuario = user.Firstname;
            newUserDb.Apellido = user.Lastname;
            newUserDb.Contraseña = user.Password;
            newUserDb.Cbu = "12345";
            newUserDb.Dnidorsal = new byte[] { 255 };
            newUserDb.Dnifrontal = new byte[] { 234 };
            _context.Usuarios.Add(newUserDb);
            _context.SaveChanges();

        }

        public UserModel LoginUser(UserModel user)
        {
            
            var userDb = (from u in _context.Usuarios
                          where u.Mail == user.Email
                          && u.Contraseña == user.Password
                          select new UserModel
                          {
                              Id = u.IdUsuario,
                              Email = u.Mail,
                              Firstname = u.NombreUsuario,
                              Lastname = u.Apellido
                          }).FirstOrDefault();
            return userDb;
        }
    }
}
