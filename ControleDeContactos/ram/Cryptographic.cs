using System.Security.Cryptography;
using System.Text;

namespace ControleDeContactos.ram
{
/*
*@author Ramadan ismaeL
*/
    public static class Cryptographic
    {
        /*public static string CreateHash(this string value)
        {
            //var hash = SHA1.Create();
            var enconding = new ASCIIEncoding();
            var array = enconding.GetBytes(value);
            var strHexa = new StringBuilder();

            //array = hash.ComputeHash(array);
            array = SHA1.HashData(array);
            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }
            return strHexa.ToString();
        }*/



        // PRIMEIRO INSTALE
        // dotnet add package BCrypt.Net-Next



        private const int WorkFactor = 12;

        /// <summary>
        /// Cria um hash seguro para a senha usando bcrypt.
        /// </summary>
        /// <param name="value">A senha em texto plano a ser hasheada.</param>
        /// <returns>O hash seguro da senha.</returns>
        /// <exception cref="ArgumentNullException">Lançado se a senha for nula ou vazia.</exception>
        public static string CreateHash(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value), "A senha não pode ser nula ou vazia.");
            }
            try
            {
                // Gera o hash com o fator de trabalho especificado
                return BCrypt.Net.BCrypt.HashPassword(value, workFactor: WorkFactor);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Ocorreu um erro ao gerar o hash da senha.", ex);
            }
        }
    }
}