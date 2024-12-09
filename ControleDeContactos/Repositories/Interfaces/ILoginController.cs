using ControleDeContactos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContactos.Repositories.Interfaces
{
/*
*@author Ramadan ismaeL
*/
    public interface ILoginController
    {
        IActionResult Login([FromBody] LoginModel login);
        string GerarTokenJWT();
    }
}