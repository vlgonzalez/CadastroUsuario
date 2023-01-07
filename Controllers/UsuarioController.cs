using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroUsuario.Context;
using CadastroUsuario.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Entrar(Usuario login)
        {
         var 
         if()
           return RedirectToAction(nameof(Index));

        return View(login.Nome);
        }

        public IActionResult RecuperarSenha()
        {
            return View();
        }
    }
}