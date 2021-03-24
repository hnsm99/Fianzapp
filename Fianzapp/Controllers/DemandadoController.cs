using Fianzapp.Models.Demandado;
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
    [RoutePrefix("Demandado")]
    public class DemandadoController : ApiController
    {
        DemandadoTransaction DT = new DemandadoTransaction();
        [HttpGet]
        [Route("GetObj")]
        public IHttpActionResult Obtener()
        {
            return Ok(DT.Get(null));
        }

        [HttpGet]
        [Route("GetObj/{id}")]
        public IHttpActionResult ObtenerWId(int id)
        {
            return Ok(DT.Get(id));
        }

        [HttpGet]
        [Route("GetList")]
        public IHttpActionResult Listar()
        {
            return Ok(DT.GetList(null));
        }

        [HttpGet]
        [Route("GetList/{id}")]
        public IHttpActionResult ObtenerId(int id)
        {
            return Ok(DT.GetList(id));
        }

        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Enviar(DemandadoIndex model)
        {
            if (!(string.IsNullOrEmpty(model.nombre_usuario_demandado) || string.IsNullOrEmpty(model.cedula_usuario_demandado) || string.IsNullOrEmpty(model.telefono_usuario_demandado) || string.IsNullOrEmpty(model.correo_usuario_demandado) || string.IsNullOrEmpty(model.direccion_usuario_demandado)))
            {
                return Ok(DT.Post(model));
            }
            else
            {
                return BadRequest("Revise los campos enviados, revise la documentación.");
            }
        }
    }
}
