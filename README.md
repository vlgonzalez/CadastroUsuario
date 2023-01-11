# CadastroUsuario
AplicaçãoC# - ASP.NET MVC - contou com a utilização do EntityFramework e SqlServer

Este projeto tem como objetivo demonstrar habilidades, diante de situações que ocorrem no dia a dia de um Desenvolvedor, com foco em suas habilidades técnicas. O
projeto tem o foco na construção de uma tela de login com toda a sua estrutura backend funcional.

1. Cadastro de novos usuários</br>
Para que um usuário obtenha este acesso, ele precisa realizar o seu cadastro informando os seguintes dados:
● nome (obrigatório);
● e-mail (obrigatório e verificar se e-mail é válido);
● senha (obrigatório);
● confirmação de senha (obrigatório e conferir se é a mesma digitada no campo senha);
Essas informações foram registradas no banco de dados para que sejam consumidas na tela de login.

2. Autenticação de um usuário
● A tela de autenticação tem dois campos para que o usuário possa informar seu e-mail e sua senha. Além disso,  temos um link para que o usuário possa clicar e ser direcionado para uma tela de recuperação de senha.
● Quando o usuário informar seus dados e realizar o envio, a autenticação é realizada utilizando a base de dados de usuários já cadastrados.
● Caso o usuário e senha informados não forem encontrados, é apresentada uma mensagem para o usuário informando o caso.
● Se ocorrer sucesso, o usuário deve é direcionado para um tela simples contendo a seguinte mensagem: “Olá [NOME_DO_USUÁRIO], seja bem vindo.”.

3. Recuperação de senha
● Esta tela é bem simples, pois possui apenas um campo para que o usuário informe o seu e-mail.
● Ao enviar a informação, é verificado na base se existe algum usuário com este e-mail. Caso não exista, uma mensagem deve é exibida para o usuário informando o problema. Em caso de sucesso, um e-mail contendo uma nova senha aleatória deve é enviada para o e-mail do usuário.

