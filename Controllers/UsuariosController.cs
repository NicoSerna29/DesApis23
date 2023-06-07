using ProyectoDesAppsPT2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            try
            {
                listaUsuarios = BDContext.Usuarios.ToList();
                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Listado de Consultas",
                    Detail = listaUsuarios
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Error al consultar",
                    Detail = ex.Message
                });
            }
        }
        [HttpPost]
        [Route("Save")]
        public IActionResult Guardar([FromBody] Usuario ObjUsu)
        {
            try
            {
                BDContext.Usuarios.Add(ObjUsu);
                var result = BDContext.SaveChanges();
                if (result > 0)
                {
                    return StatusCode(StatusCodes.Status201Created, new
                    {
                        code = "OK",
                        message = "Datos de la consulta Almacendos Exitosamente",
                        Detail = ""
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        code = "OK",
                        message = "No fue posible Almacenar los Datos",
                        Detail = ""
                    });

                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Error al Guardar",
                    Detail = ex.Message
                });
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Editar([FromBody] Usuario ObjUsu)
        {

            Usuario Usu = BDContext.Usuarios.Find(ObjUsu.IdUsuario);

            if (Usu == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    code = "HTTP 400",
                    message = "No es posible Editar Datos",
                    Detail = ""
                });
            }

            try
            {
                Usu.NombreUsuario= ObjUsu.NombreUsuario;
                Usu.Descripcion = string.IsNullOrEmpty(ObjUsu.Descripcion) ? Usu.Descripcion : ObjUsu.Descripcion;
                Usu.EmailUsuario = string.IsNullOrEmpty(ObjUsu.EmailUsuario) ? Usu.EmailUsuario : ObjUsu.EmailUsuario;

                if (ObjUsu.TelefonoUsuario != 0 && ObjUsu.TelefonoUsuario != null)
                {
                    Usu.TelefonoUsuario = ObjUsu.TelefonoUsuario;
                }
                Usu.DireccionUsuario = string.IsNullOrEmpty(ObjUsu.DireccionUsuario) ? Usu.DireccionUsuario : ObjUsu.DireccionUsuario;
                Usu.FechaConsulta = ObjUsu.FechaConsulta.HasValue ? ObjUsu.FechaConsulta.Value : Usu.FechaConsulta;

                BDContext.Usuarios.Update(Usu);
                BDContext.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, new
                {
                    code = "OK",
                    message = "Datos Modificados Exitosamente",
                    Detail = ""
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Error al Modificar",
                    Detail = ex.Message
                });
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Eliminar(int id)
        {

            Usuario Usu = BDContext.Usuarios.Find(id);

            if (Usu == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    code = "HTTP 400",
                    message = "Usuario no Encontrado",
                    Detail = ""
                });
            }
            try
            {
                BDContext.Usuarios.Remove(Usu);
                BDContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Consulta Eliminada Exitosamente",
                    Detail = ""
                });



            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Error al Eliminar",
                    Detail = ex.Message
                });
            }
        }
    }
}
