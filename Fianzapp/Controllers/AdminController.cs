using Fianzapp.Models.Administrador;
using Fianzapp.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fianzapp.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("Admin")]
    public class AdminController : ApiController
    {
        AdminTransaction AT = new AdminTransaction();
        [HttpGet]
        [Route("GetObj")]
        public IHttpActionResult Obtener()
        {
            return Ok(AT.Get(null));
        }

        [HttpGet]
        [Route("GetObj/{id}")]
        public IHttpActionResult ObtenerWId(int id)
        {
            return Ok(AT.Get(id));
        }

        [HttpGet]
        [Route("GetList")]
        public IHttpActionResult Listar()
        {
            return Ok(AT.GetList(null));
        }

        [HttpGet]
        [Route("GetList/{id}")]
        public IHttpActionResult ObtenerId(int id)
        {
            return Ok(AT.GetList(id));
        }

        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Enviar(AdminEdit model)
        {
            bool List_Val = false;
            if (!(string.IsNullOrEmpty(model.nombre_administrador) || string.IsNullOrEmpty(model.documento_administrador) || string.IsNullOrEmpty(model.correo_administrador) || string.IsNullOrEmpty(model.usuario_administrador) || string.IsNullOrEmpty(model.contrasena_administrador) || model.LstRol.Count == 0))
            {
                List_Val = model.LstRol.Where(x => x.id == model.id_rol) != null ? true : false;
                if (List_Val)
                {
                    model.LstRol = null;
                    return Ok(AT.Post(model));
                }
                else
                {
                    return BadRequest("Los campos llenados mediante las listas no coinciden, por favor verifique.");
                }
            }
            else
            {
                return BadRequest("Revise los campos enviados, revise la documentación.");
            }
        }
    }
}
