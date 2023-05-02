using ProyectoDesAppsPT2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoDesAppsPT2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public readonly WebAppiDesAppsContext BDContext;
        public UsuariosController (WebAppiDesAppsContext context){
            BDContext = context;
        }
        [HttpGet]
        [Route("Lista")]
        public IActionResult Listar()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            List<Tipo> listaTipos = new List<Tipo>();

            try
            {
                listaUsuarios = BDContext.Usuarios.ToList();
                listaTipos= BDContext.Tipos.ToList();

                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Consulta Exitosa",
                    ListaUsuarios = listaUsuarios, listaTipos
                }) ;
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Error al Realizar la Consulta",
                    Detail = ex.Message
                });
            }
        }

    }
}
