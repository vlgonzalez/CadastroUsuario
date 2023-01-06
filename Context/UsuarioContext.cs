using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroUsuario.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.Context
{
    public class UsuarioContext : DbContext
     {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}