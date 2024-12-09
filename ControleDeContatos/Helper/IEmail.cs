namespace ControleDeContatos.Helper
{
/*
*@author Ramadan ismaeL
*/
    public interface IEmail
    {
        bool Enviar(string email, string assunto, string mensagem);
    }
}