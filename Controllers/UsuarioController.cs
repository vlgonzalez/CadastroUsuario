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
        public IActionResult Entrar(Usuario login)
        { 
          var loginUser = _context.Usuarios.Where(a => a.Email.Equals(login.Email) && a.Senha.Equals(login.Senha)).FirstOrDefault();

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
        public IActionResult RecuperarSenha(Usuario email)
        {              
        var loginemail = _context.Usuarios.Where(e => e.Email.Equals(email.Email)).FirstOrDefault();

        if(loginemail !=null)
        {   
           
            return BadRequest("achou");
        }else
        {
           return BadRequest("Usuario ou senha invalidos");
        }
    

        }
           
        }
}
    

