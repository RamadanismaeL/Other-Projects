using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraAPI.Models;
namespace MinhaPrimeiraAPI.Controllers
{
/*
*@author Ramadan ismaeL
*/
    [Route("api/controller")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<UsuarioModel> Get()
        {
            List<UsuarioModel> usuarioModels = new List<UsuarioModel>();

            usuarioModels.Add(new UsuarioModel() {Id = 1, Nome = "Ramadan Ismael", Email = "ramadan.ismael"});

            return usuarioModels;
        }

        [HttpGet("{id}")]
        public UsuarioModel Get(int id)
        {
            UsuarioModel usuario = new UsuarioModel() {Id = 1, Nome = "Ramadan Ismael", Email = "ramadan.ismael@hotmail.com"};
            return usuario;
        }

        [HttpPost]
        public void Post([FromBody] UsuarioModel usuario)
        {}

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {}

        [HttpDelete("{id}")]
        public void Delete(int id)
        {}
    }
}