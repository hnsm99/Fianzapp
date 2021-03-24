using Fianzapp.Models.DB;
using Fianzapp.Models.Demandado;
using Fianzapp.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Fianzapp.Transaction
{
    public class DemandadoTransaction
    {
        FianzappEntities DB = null;
        Response response = null;

        public dynamic Get(int? id)
        {
            DemandadoIndex DI = new DemandadoIndex();
            try
            {
                DB = new FianzappEntities();
                DB.Configuration.LazyLoadingEnabled = true;
                response = new Response();
                Demandado DM = id != null ? DB.Demandado.Where(x => x.id_usuario_demandado == id).FirstOrDefault() : null;
                DI = new DemandadoIndex()
                {
                    id_usuario_demandado=DM!=null?DM.id_usuario_demandado:0,
                    nombre_usuario_demandado=DM!=null?DM.nombre_usuario_demandado:"",
                    cedula_usuario_demandado=DM!=null?DM.cedula_usuario_demandado:"",
                    telefono_usuario_demandado=DM!=null?DM.telefono_usuario_demandado:"",
                    celular_usuario_demandado=DM!=null?DM.celular_usuario_demandado:"",
                    correo_usuario_demandado=DM!=null?DM.correo_usuario_demandado:"",
                    direccion_usuario_demandado=DM!=null?DM.direccion_usuario_demandado:""
                };
                response.Successfully = true;
                response.Code = 200;
                response.Message = "Consulta realizada con éxito.";
                response.Result = DI;
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
            DemandadoIndex DI = new DemandadoIndex();
            try
            {
                DB = new FianzappEntities();
                DB.Configuration.LazyLoadingEnabled = true;
                response = new Response();
                List<Demandado> Dem;
                Dem = id == null ? DB.Demandado.ToList() : DB.Demandado.Where(x => x.id_usuario_demandado == id).ToList();
                if (Dem.Count > 0)
                {
                    foreach (Demandado D in Dem)
                    {
                        DI = new DemandadoIndex()
                        {
                            id_usuario_demandado = D.id_usuario_demandado,
                            nombre_usuario_demandado = D.nombre_usuario_demandado,
                            cedula_usuario_demandado = D.cedula_usuario_demandado,
                            telefono_usuario_demandado = D.telefono_usuario_demandado,
                            celular_usuario_demandado = D.celular_usuario_demandado,
                            correo_usuario_demandado = D.correo_usuario_demandado,
                            direccion_usuario_demandado = D.direccion_usuario_demandado
                        };
                    }
                    response.Message = "Consulta realizada con exito.";
                    response.Result = DI;
                }
                else
                {
                    response.Message = "No se encontro ningun Cliente";
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
        public dynamic Post(DemandadoIndex model)
        {
            DB = new FianzappEntities();
            response = new Response();
            using (var transaction = DB.Database.BeginTransaction())
            {
                try
                {
                    Demandado DM = DB.Demandado.Where(x => x.cedula_usuario_demandado.ToUpper().Equals(model.cedula_usuario_demandado.ToUpper()) && x.correo_usuario_demandado.ToUpper().Equals(model.correo_usuario_demandado.ToUpper())).FirstOrDefault();
                    if (model.id_usuario_demandado == 0)
                    {
                        if (DM == null)
                        {
                            DM = new Demandado()
                            {
                                nombre_usuario_demandado = model.nombre_usuario_demandado,
                                cedula_usuario_demandado = model.cedula_usuario_demandado,
                                telefono_usuario_demandado = model.telefono_usuario_demandado,
                                celular_usuario_demandado = model.celular_usuario_demandado,
                                correo_usuario_demandado = model.correo_usuario_demandado,
                                direccion_usuario_demandado = model.direccion_usuario_demandado
                            };
                            DB.Demandado.Add(DM);
                            DB.SaveChanges();
                            response.Successfully = true;
                            response.Code = 201;
                            response.Message = "Inserción del Cliente realizado con éxito.";
                            response.Result = "Successfully";
                            transaction.Commit();
                            //Opcion de envio correo al crear Administrador
                        }
                        else
                        {
                            response.Successfully = false;
                            response.Code = 200;
                            response.Message = string.Format("Ya existe un Cliente con ese correo {0} y con ese nit {1}", model.correo_usuario_demandado, model.cedula_usuario_demandado);
                            response.Result = null;
                        }
                    }
                    else
                    {
                        //Cli = DB.Cliente.Where(x => x.usuario_cliente.ToUpper().Equals(model.usuario_cliente.ToUpper()) && x.nit_cliente.ToUpper().Equals(model.nit_cliente.ToUpper()) && x.correo_cliente.ToUpper().Equals(model.correo_cliente.ToUpper())).FirstOrDefault();
                        //if (Cli != null)
                        //{
                        //    //Cli.nombre_cliente = model.nombre_cliente;

                        //    //Admin.nombre_administrador = model.nombre_administrador;
                        //    //Admin.documento_administrador = model.documento_administrador;
                        //    DB.Entry(Cli).State = EntityState.Modified;
                        //    DB.SaveChanges();
                        //    response.Successfully = true;
                        //    response.Code = 200;
                        //    response.Message = "Actualización de datos realizada con éxito.";
                        //    response.Result = "Successfully";
                        //    transaction.Commit();
                        //}
                        //else
                        //{
                        //    response.Successfully = false;
                        //    response.Code = 200;
                        //    response.Message = string.Format("No se logró validar el Cliente con este usuario {0}, con este correo {1} y con este nit {2}", model.usuario_cliente, model.correo_cliente, model.nit_cliente);
                        //    response.Result = null;
                        //}
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