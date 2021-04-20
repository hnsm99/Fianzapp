using Fianzapp.Models.Cliente;
using Fianzapp.Models.DB;
using Fianzapp.Models.Rol;
using Fianzapp.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Fianzapp.Transaction
{
    public class ClienteTransaction
    {
        FianzappEntities DB = null;
        Response response = null;

        public dynamic Get(int? id)
        {
            ClienteIndex CI = new ClienteIndex();
            RolGet RG = new RolGet();
            List<RolGet> LstRG = new List<RolGet>();
            try
            {
                DB = new FianzappEntities();
                DB.Configuration.LazyLoadingEnabled = true;
                response = new Response();
                List<Rol> rol = DB.Rol.ToList();
                Cliente Cli = id != null ? DB.Cliente.Where(x => x.id_cliente == id).FirstOrDefault() : null;
                if (rol.Count > 0)
                {
                    foreach (Rol r in rol)
                    {
                        RG = new RolGet()
                        {
                            id = r.id,
                            Nombre_rol = r.Nombre_rol
                        };
                        LstRG.Add(RG);
                    }
                }
                CI = new ClienteIndex()
                {
                    id_cliente = Cli != null ? Cli.id_cliente : 0,
                    nombre_cliente = Cli != null ? Cli.nombre_cliente : "",
                    nit_cliente = Cli != null ? Cli.nit_cliente : "",
                    telefono_cliente = Cli != null ? Cli.telefono_cliente : "",
                    celular_cliente = Cli != null ? Cli.celular_cliente : "",
                    direccion_cliente = Cli != null ? Cli.direccion_cliente : "",
                    correo_cliente = Cli != null ? Cli.correo_cliente : "",
                    usuario_cliente = Cli != null ? Cli.usuario_cliente : "",
                    numero_fianza = Cli != null ? Cli.numero_fianza : 0,
                    roles_id=Cli!=null?Cli.roles_id:0,
                    LstRol = LstRG
                };
                response.Successfully = true;
                response.Code = 200;
                response.Message = "Consulta realizada con éxito.";
                response.Result = CI;
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
            ClienteList CL = new ClienteList();
            try
            {
                DB = new FianzappEntities();
                DB.Configuration.LazyLoadingEnabled = true;
                response = new Response();
                List<Rol> rol = DB.Rol.ToList();
                List<Cliente> Cli;
                if (rol.Count > 0)
                {
                    foreach (Rol r in rol)
                    {
                        RolGet RG = new RolGet()
                        {
                            id = r.id,
                            Nombre_rol = r.Nombre_rol
                        };
                    }
                }
                if (id == null)
                {
                    Cli = DB.Cliente.ToList();
                }
                else
                {
                    Cli = DB.Cliente.Where(x => x.id_cliente == id).ToList();
                }
                if (Cli.Count > 0)
                {
                    foreach (Cliente C in Cli)
                    {
                        CL = new ClienteList()
                        {
                            id_cliente=C.id_cliente,
                            nombre_cliente=C.nombre_cliente,
                            nit_cliente=C.nit_cliente,
                            telefono_cliente=C.telefono_cliente,
                            celular_cliente=C.celular_cliente,
                            direccion_cliente=C.celular_cliente,
                            correo_cliente=C.correo_cliente,
                            usuario_cliente=C.usuario_cliente,
                            numero_fianza=C.numero_fianza,
                            roles_id=C.roles_id,
                            Rol=rol.Where(x=>x.id==C.roles_id).Select(x=>x.Nombre_rol).FirstOrDefault()
                        };
                    }
                    response.Message = "Consulta realizada con exito.";
                    response.Result = CL;
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
        public dynamic Post(ClienteEdit model)
        {
            DB = new FianzappEntities();
            response = new Response();
            using (var transaction = DB.Database.BeginTransaction())
            {
                try
                {
                    Cliente Cli = DB.Cliente.Where(x => x.usuario_cliente.ToUpper().Equals(model.usuario_cliente.ToUpper()) && x.nit_cliente.ToUpper().Equals(model.nit_cliente.ToUpper()) && x.correo_cliente.ToUpper().Equals(model.correo_cliente.ToUpper())).FirstOrDefault();
                    if (model.id_cliente == 0)
                    {
                        if (Cli == null)
                        {
                            Cli = new Cliente()
                            {
                                nombre_cliente = model.nombre_cliente,
                                nit_cliente = model.nit_cliente,
                                telefono_cliente = model.telefono_cliente,
                                celular_cliente = model.celular_cliente,
                                direccion_cliente = model.direccion_cliente,
                                correo_cliente = model.correo_cliente,
                                usuario_cliente = model.usuario_cliente,
                                contrasena_cliente = response.Encriptar(model.contrasena_cliente),
                                numero_fianza = model.numero_fianza,
                                roles_id = model.roles_id
                            };
                            DB.Cliente.Add(Cli);
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
                            response.Message = string.Format("Ya existe un Cliente con ese usuario {0}, con ese correo {1} y con ese nit {2}", model.usuario_cliente, model.correo_cliente, model.nit_cliente);
                            response.Result = null;
                        }
                    }
                    else
                    {
                        Cli = DB.Cliente.Where(x => x.usuario_cliente.ToUpper().Equals(model.usuario_cliente.ToUpper()) && x.nit_cliente.ToUpper().Equals(model.nit_cliente.ToUpper()) && x.correo_cliente.ToUpper().Equals(model.correo_cliente.ToUpper())).FirstOrDefault();
                        if (Cli != null)
                        {
                            //Cli.nombre_cliente = model.nombre_cliente;

                            //Admin.nombre_administrador = model.nombre_administrador;
                            //Admin.documento_administrador = model.documento_administrador;
                            DB.Entry(Cli).State = EntityState.Modified;
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
                            response.Message = string.Format("No se logró validar el Cliente con este usuario {0}, con este correo {1} y con este nit {2}", model.usuario_cliente, model.correo_cliente, model.nit_cliente);
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