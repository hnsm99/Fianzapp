using Fianzapp.Models.Cliente;
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
    [RoutePrefix("Cus")]
    public class CustomerController : ApiController
    {
        ClienteTransaction CT = new ClienteTransaction();
        [HttpGet]
        [Route("GetObj")]
        public IHttpActionResult Obtener()
        {
            return Ok(CT.Get(null));
        }

        [HttpGet]
        [Route("GetObj/{id}")]
        public IHttpActionResult ObtenerWId(int id)
        {
            return Ok(CT.Get(id));
        }

        [HttpGet]
        [Route("GetList")]
        public IHttpActionResult Listar()
        {
            return Ok(CT.GetList(null));
        }

        [HttpGet]
        [Route("GetList/{id}")]
        public IHttpActionResult ObtenerId(int id)
        {
            return Ok(CT.GetList(id));
        }

        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Enviar(ClienteEdit model)
        {
            bool List_Val = false;
            if (!string.IsNullOrEmpty(model.correo_cliente)||!string.IsNullOrEmpty(model.nombre_cliente)||!string.IsNullOrEmpty(model.nit_cliente)||!string.IsNullOrEmpty(model.usuario_cliente)||!string.IsNullOrEmpty(model.numero_fianza.ToString())||model.roles_id!=0||!string.IsNullOrEmpty(model.contrasena_cliente))
            {
                List_Val = model.LstRol.Where(x => x.id == model.roles_id) != null ? true : false;
                if (List_Val)
                {
                    model.LstRol = null;
                    return Ok(CT.Post(model));
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
