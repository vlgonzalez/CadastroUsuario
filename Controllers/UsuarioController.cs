using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroUsuario.Context;
using CadastroUsuario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;

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
        
        MailMessage mail = new MailMessage();
                mail.To.Add(loginEmail.Email);
                mail.From= new MailAddress("Email_do_remetente");
                mail.Subject = "Redefinir senha";
                string Body = $"Ola,{loginEmail.Nome}, sua nova senha é {loginEmail.Senha}";
                mail.Body = Body;
                mail.IsBodyHtml = true;
 
                //Instância smtp do servidor, neste caso o gmail.
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("Email_do_remetente", "Senha_email");// Login e senha do e-mail.
                smtp.EnableSsl = true;
                smtp.Send(mail);

                TempData["MensagemEmail"] = $"Email enviado com sucesso";
                return View("Index");
        }
        
        TempData["MensagemErro"] = $"Email incorreto, verifique o dado informado";
        return RedirectToAction("Recuperar");
        
        }
           
        }
}
    

