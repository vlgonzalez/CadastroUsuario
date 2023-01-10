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
                TempData["MensagemSucesso"] = $"Usuario criado com sucesso";
                return RedirectToAction(nameof(Index));
            }
            TempData["MensagemErro"] = $"Dados incorretos, verifique os dados informados";
            return RedirectToAction("Cadastro");            
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
           TempData["MensagemErro"] = $"Senhas ou Email incorretos, verifique os dados informados";
           return RedirectToAction("Index");
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
        _context.Usuarios.Update(loginEmail);
        _context.SaveChanges();
        
            return BadRequest(loginEmail.Senha);
        }
        
        TempData["MensagemErro"] = $"Email incorreto, verifique o dado informado";
        return RedirectToAction("Recuperar");
        
        }
           
        }
}
    

