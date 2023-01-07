using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuario.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        //nunca deve apenas implementar verificações no código do cliente - seu código de cliente e ser facilmente ignorado - o servidor deve executar as verificações - seu cliente pode fazê-las também - para economizar uma viagem de ida e volta do servidor e melhorar a experiência do usuário - mas o servidor deve verificar todos os envios
        
        [Compare("Senha", ErrorMessage = "Senhas Divergentes")]
        public string ConfirmarSenha { get; set; }
    }
}