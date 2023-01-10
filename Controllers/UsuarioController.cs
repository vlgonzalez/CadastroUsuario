using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroUsuario.Context;
using CadastroUsuario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace CadastroUsuario.Controllers
{
    public class UsuarioController: Controller
    {
    
         private readonly UsuarioContext _context;
        
        public UsuarioController(UsuarioContext context)
        {
            _context = context;
        }
        
        public IActionResult Cadastro()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Criar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return BadRequest("Senhas divergentes");
            
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Entrar(string email, string senha)
        { 
          var loginUser = _context.Usuarios.Where(a => a.Email.Equals(email) && a.Senha.Equals(senha)).FirstOrDefault();

        if(loginUser !=null)
        {   
           
            return View(loginUser);
        }else
        {
           return BadRequest("Usuario ou senha invalidos");
        }
       
        }

        public IActionResult Recuperar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RecuperarSenha(string email)
        {              
        
        var loginEmail =  _context.Usuarios.FirstOrDefault(e => e.Email == email);

        if(loginEmail != null)
        {   
        loginEmail.Senha = Guid.NewGuid().ToString().Substring(0,8);
        
            return BadRequest("achou");
        }
        
        return BadRequest("Email não encontrado, verifique o valor digitado");
        
        }
           
        }
}
    

