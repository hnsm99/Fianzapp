using Fianzapp.Models.Proceso;
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
    [RoutePrefix("Process")]
    public class ProcesoController : ApiController
    {
        ProcesoTransaction CT = new ProcesoTransaction();
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
        public IHttpActionResult Enviar(ProcesoEdit model)
        {
            bool List_Val = false;
            if (!(string.IsNullOrEmpty(model.numero_proceso.ToString()) || string.IsNullOrEmpty(model.id_administrador.ToString()) || string.IsNullOrEmpty(model.id_cliente.ToString()) || string.IsNullOrEmpty(model.id_estado.ToString()) || string.IsNullOrEmpty(model.id_demandado.ToString()) || string.IsNullOrEmpty(model.archivo_proceso)))
            {
                List_Val = model.LstAdmin.Where(x => x.id_admin == model.id_administrador) != null ? true : false;
                List_Val = model.LstCliente.Where(x => x.id_cliente == model.id_cliente) != null ? true : false;
                List_Val = model.LstDemandado.Where(x => x.id_usuario_demandado == model.id_demandado) != null ? true : false;
                List_Val = model.LstEstado_Proc.Where(x => x.id_estado_solicitud == model.id_estado) != null ? true : false;
                if (List_Val)
                {
                    model.LstAdmin = null;
                    model.LstCliente = null;
                    model.LstDemandado = null;
                    model.LstEstado_Proc = null;
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
