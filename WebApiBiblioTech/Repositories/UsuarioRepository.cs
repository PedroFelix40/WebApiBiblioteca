﻿using Microsoft.EntityFrameworkCore;
using webapibibliotech.Contexts;
using webapibibliotech.Domains;
using webapibibliotech.Interfaces;
using webapibibliotech.Utils;

namespace webapibibliotech.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly BiblioTechContext _context;

        public UsuarioRepository()
        {
            _context = new BiblioTechContext();
        }

        public Usuarios BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuarios usuarioBuscado = _context.Usuarios.Select(u => new Usuarios 
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,

                    TipoUsuario = new TiposUsuario
                    {
                        IDTipoUsuario = u.IDTipoUsuario,
                        TituloTipoUsuario = u.TipoUsuario!.TituloTipoUsuario
                    }

                }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuarios BuscarPorId(Guid id)
        {
            try
            {
                return _context.Usuarios.Include(t => t.TipoUsuario).FirstOrDefault(u => u.IdUsuario == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _context.Usuarios.Add(usuario);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Usuarios> ListarUsuarios()
        {
            try
            {
                return _context.Usuarios.Select( u =>  new Usuarios 
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,

                    TipoUsuario = new TiposUsuario
                    {
                        IDTipoUsuario = u.IDTipoUsuario,
                        TituloTipoUsuario = u.TipoUsuario!.TituloTipoUsuario
                    }
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
