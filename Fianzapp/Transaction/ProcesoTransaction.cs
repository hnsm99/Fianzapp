using Fianzapp.Models;
using Fianzapp.Models.Administrador;
using Fianzapp.Models.Cliente;
using Fianzapp.Models.DB;
using Fianzapp.Models.Demandado;
using Fianzapp.Models.Proceso;
using Fianzapp.Models.Rol;
using Fianzapp.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace Fianzapp.Transaction
{
    public class ProcesoTransaction
    {
        FianzappEntities DB = null;
        Response response = null;

        public dynamic Get(int? id)
        {
            ProcesoIndex PI = new ProcesoIndex();
            Estado_Procesos EP = new Estado_Procesos();
            DemandadoIndex DI = new DemandadoIndex();
            ClienteIndex CI = new ClienteIndex();
            AdminIndex AI = new AdminIndex();
            List<Estado_Procesos> LstEP = new List<Estado_Procesos>();
            List<DemandadoIndex> LstDI = new List<DemandadoIndex>();
            List<ClienteIndex> LstCI = new List<ClienteIndex>();
            List<AdminIndex> LstAI = new List<AdminIndex>();
            try
            {
                DB = new FianzappEntities();
                DB.Configuration.LazyLoadingEnabled = true;
                response = new Response();
                foreach (Estado_Proceso e in DB.Estado_Proceso.ToList())
                {
                    EP = new Estado_Procesos()
                    {
                        id_estado_solicitud = e.id_estado_solicitud,
                        nombre_estado_solicitud = e.nombre_estado_solicitud
                    };
                    LstEP.Add(EP);
                }
                foreach (Demandado d in DB.Demandado.ToList())
                {
                    DI = new DemandadoIndex()
                    {
                        id_usuario_demandado = d.id_usuario_demandado,
                        nombre_usuario_demandado = d.nombre_usuario_demandado,
                        cedula_usuario_demandado = d.cedula_usuario_demandado,
                        correo_usuario_demandado = d.correo_usuario_demandado
                    };
                    LstDI.Add(DI);
                }
                foreach (Cliente c in DB.Cliente.ToList())
                {
                    CI = new ClienteIndex()
                    {
                        id_cliente = c.id_cliente,
                        nombre_cliente = c.nombre_cliente,
                        nit_cliente = c.nit_cliente,
                        correo_cliente = c.correo_cliente
                    };
                    LstCI.Add(CI);
                }
                foreach (Administrador a in DB.Administrador.ToList())
                {
                    AI = new AdminIndex()
                    {
                        id_admin = a.id_admin,
                        nombre_administrador = a.nombre_administrador,
                        usuario_administrador = a.usuario_administrador,
                        documento_administrador = a.documento_administrador,
                        correo_administrador = a.correo_administrador
                    };
                    LstAI.Add(AI);
                }
                Proceso proc = id != null ? DB.Proceso.Where(x => x.id_proceso == id).FirstOrDefault() : null;
                PI = new ProcesoIndex()
                {
                    LstAdmin = LstAI,
                    LstCliente = LstCI,
                    LstDemandado = LstDI,
                    LstEstado_Proc = LstEP,
                    id_proceso = proc != null ? proc.id_proceso : 0,
                    numero_proceso = proc != null ? proc.id_proceso : 0,
                    descripcion = proc != null ? proc.descripcion : "",
                    id_administrador = proc != null ? proc.id_administrador : 0,
                    id_cliente = proc != null ? proc.id_cliente : 0,
                    id_demandado = proc != null ? proc.id_demandado : 0,
                    id_estado = proc != null ? proc.id_estado : 0,
                    archivo_proceso = proc != null ? proc.archivo_proceso : "",
                    Fecha_creacion=DateTime.Now
                };
                response.Successfully = true;
                response.Code = 200;
                response.Message = "Consulta realizada con éxito.";
                response.Result = PI;
            }
            catch (Exception Exc)
            {
                response.Successfully = false;
                response.Code = 204;
                response.Message = Exc.Message.ToString();
                response.Result = null;
            }
            return response;
        }
        public dynamic GetList(int? id)
        {
            ProcesoList PL = new ProcesoList();
            try
            {
                DB = new FianzappEntities();
                DB.Configuration.LazyLoadingEnabled = true;
                response = new Response();
                List<Estado_Proceso> Est_Proc = DB.Estado_Proceso.ToList();
                List<Demandado> Dem = DB.Demandado.ToList();
                List<Cliente> Cli = DB.Cliente.ToList();
                List<Administrador> Adm = DB.Administrador.ToList();
                List<Proceso> Pro = id == null ? DB.Proceso.ToList() : DB.Proceso.Where(x => x.id_proceso == id).ToList();
                if (Pro.Count > 0)
                {
                    foreach (Proceso P in Pro)
                    {
                        PL = new ProcesoList()
                        {
                            id_proceso = P.id_proceso,
                            numero_proceso = P.numero_proceso,
                            id_estado = P.id_estado,
                            estado = Est_Proc!=null? Est_Proc.Where(x=>x.id_estado_solicitud==P.id_estado).Select(x=>x.nombre_estado_solicitud).ToString():"",
                            id_demandado=P.id_demandado,
                            demandado=Dem!=null?Dem.Where(x=>x.id_usuario_demandado==P.id_demandado).Select(x=>x.nombre_usuario_demandado).ToString():"",
                            id_cliente=P.id_cliente,
                            cliente=Cli!=null?Cli.Where(x=>x.id_cliente==P.id_cliente).Select(x=>x.nombre_cliente).ToString():"",
                            descripcion=P.descripcion,
                            archivo_proceso=P.archivo_proceso,
                            id_administrador=P.id_administrador,
                            administrador=Adm!=null?Adm.Where(x=>x.id_admin==P.id_administrador).Select(x=>x.nombre_administrador).ToString():"",
                            Fecha_creacion=P.Fecha_creacion
                        };
                    }
                    response.Message = "Consulta realizada con exito.";
                    response.Result = PL;
                }
                else
                {
                    response.Message = "No se encontro ningun Proceso";
                    response.Result = null;
                }
                response.Successfully = true;
                response.Code = 200;
            }
            catch (Exception Exc)
            {
                response.Successfully = false;
                response.Code = 204;
                response.Message = Exc.Message.ToString();
                response.Result = null;
            }
            return response;
        }
        public dynamic Post(ProcesoEdit model)
        {
            DB = new FianzappEntities();
            response = new Response();
            using (var transaction = DB.Database.BeginTransaction())
            {
                try
                {
                    List<Demandado> Dem = DB.Demandado.ToList();
                    List<Cliente> Cli = DB.Cliente.ToList();
                    Proceso Pro = DB.Proceso.Where(x => x.id_cliente.Equals(model.id_cliente) && x.id_demandado.Equals(model.id_demandado) && x.numero_proceso.Equals(model.numero_proceso)).FirstOrDefault();
                    if (model.id_proceso == 0)
                    {
                        if (Pro == null)
                        {
                            Pro = new Proceso
                            {
                                numero_proceso = model.numero_proceso,
                                id_estado = model.id_estado,
                                id_demandado = model.id_demandado,
                                id_cliente = model.id_cliente,
                                descripcion = model.descripcion,
                                id_administrador=model.id_administrador,
                                Fecha_creacion=model.Fecha_creacion
                            };
                            if (!string.IsNullOrEmpty(model.archivo_proceso))
                            {
                                if (File.Exists(model.archivo_proceso))
                                {
                                    try
                                    {
                                        File.Copy(model.archivo_proceso, "C:/TEMP/"+model.archivo_proceso.Split('/')[model.archivo_proceso.Split('/').Length-1],true);
                                        Pro.archivo_proceso = model.archivo_proceso;
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                }
                            }
                            DB.Proceso.Add(Pro);
                            DB.SaveChanges();
                            response.Successfully = true;
                            response.Code = 201;
                            response.Message = "Inserción del Proceso realizado con éxito.";
                            response.Result = "Successfully";
                            transaction.Commit();
                            //Opcion de envio correo al crear Administrador
                        }
                        else
                        {
                            response.Successfully = false;
                            response.Code = 200;
                            response.Message = string.Format("Ya existe un Proceso con ese Demandado {0}, con ese Cliente {1} y con ese numero de Proceso {2}", Dem.Where(x=>x.id_usuario_demandado==model.id_demandado).Select(x=>x.nombre_usuario_demandado).ToString(), Cli.Where(x=>x.id_cliente==model.id_cliente).Select(x=>x.nombre_cliente).ToString(), model.numero_proceso);
                            response.Result = null;
                        }
                    }
                    else
                    {
                        Pro = DB.Proceso.Where(x => x.id_proceso.Equals(model.id_proceso)).FirstOrDefault();
                        if (Pro != null)
                        {
                            //Cli.nombre_cliente = model.nombre_cliente;

                            //Admin.nombre_administrador = model.nombre_administrador;
                            //Admin.documento_administrador = model.documento_administrador;
                            DB.Entry(Pro).State = EntityState.Modified;
                            DB.SaveChanges();
                            response.Successfully = true;
                            response.Code = 200;
                            response.Message = "Actualización de datos realizada con éxito.";
                            response.Result = "Successfully";
                            transaction.Commit();
                        }
                        else
                        {
                            response.Successfully = false;
                            response.Code = 200;
                            response.Message = string.Format("No se logró validar el Cliente con este usuario {0}, con este correo {1} y con este nit {2}", Dem.Where(x => x.id_usuario_demandado == model.id_demandado).Select(x => x.nombre_usuario_demandado).ToString(), Cli.Where(x => x.id_cliente == model.id_cliente).Select(x => x.nombre_cliente).ToString(), model.numero_proceso);
                            response.Result = null;
                        }
                    }
                }
                catch (Exception Exc)
                {
                    transaction.Rollback();
                    response.Successfully = false;
                    response.Code = 400;
                    response.Message = "Error In the Method, Error: " + Exc.Message.ToString();
                    response.Result = "Error in the Method";
                }
            }
            return response;
        }
    }
}