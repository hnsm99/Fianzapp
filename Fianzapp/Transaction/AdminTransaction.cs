using Fianzapp.Models.Administrador;
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
    public class AdminTransaction
    {
        FianzappEntities DB = null;
        Response response = null;

        public dynamic Get(int? id)
        {
            AdminIndex AI = new AdminIndex();
            RolGet RG = new RolGet();
            List<RolGet> LstRG = new List<RolGet>();
            try
            {
                DB = new FianzappEntities();
                DB.Configuration.LazyLoadingEnabled = true;
                response = new Response();
                List<Rol> rol = DB.Rol.ToList();
                Administrador Admin = id != null ? DB.Administrador.Where(x => x.id_admin == id).FirstOrDefault() : null;
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
                AI = new AdminIndex()
                {
                    id_admin = Admin != null ? Admin.id_admin : 0,
                    nombre_administrador = Admin != null ? Admin.nombre_administrador : "",
                    correo_administrador = Admin != null ? Admin.correo_administrador : "",
                    documento_administrador = Admin != null ? Admin.documento_administrador : "",
                    usuario_administrador = Admin != null ? Admin.usuario_administrador : "",
                    id_rol = Admin != null ? Admin.id_rol : 0,
                    contrasena_administrador = "",
                    LstRol = LstRG
                };
                response.Successfully = true;
                response.Code = 200;
                response.Message = "Consulta realizada con éxito.";
                response.Result = AI;
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
            AdminList AL = new AdminList();
            try
            {
                DB = new FianzappEntities();
                DB.Configuration.LazyLoadingEnabled = true;
                response = new Response();
                List<Rol> rol = DB.Rol.ToList();
                List<Administrador> Admin;
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
                    Admin = DB.Administrador.ToList();
                }
                else
                {
                    Admin = DB.Administrador.Where(x => x.id_admin == id).ToList();
                }
                if (Admin.Count > 0)
                {
                    foreach (Administrador Adm in Admin)
                    {
                        AL = new AdminList()
                        {
                            id_admin = Adm.id_admin,
                            nombre_administrador = Adm.nombre_administrador,
                            correo_administrador = Adm.correo_administrador,
                            documento_administrador = Adm.documento_administrador,
                            usuario_administrador = Adm.usuario_administrador,
                            id_rol = Adm.id_rol,
                            rol = rol.Where(x => x.id == Adm.id_rol).Select(x => x.Nombre_rol).FirstOrDefault()
                        };
                    }
                    response.Message = "";
                    response.Result = AL;
                }
                else
                {
                    response.Message = "No se encontro ningun Administrador";
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
        public dynamic Post(AdminEdit model)
        {
            DB = new FianzappEntities();
            response = new Response();
            using (var transaction = DB.Database.BeginTransaction())
            {
                try
                {
                    Administrador Admin = DB.Administrador.Where(x => x.usuario_administrador.ToUpper().Equals(model.usuario_administrador.ToUpper()) && x.correo_administrador.ToUpper().Equals(model.correo_administrador.ToUpper())).FirstOrDefault();
                    if (model.id_admin == 0)
                    {
                        if (Admin == null)
                        {
                            Admin = new Administrador()
                            {
                                nombre_administrador=model.nombre_administrador,
                                documento_administrador=model.documento_administrador,
                                correo_administrador=model.correo_administrador,
                                usuario_administrador=model.usuario_administrador,
                                contrasena_administrador= response.Encriptar(model.contrasena_administrador),
                                id_rol=model.id_rol
                            };
                            DB.Administrador.Add(Admin);
                            DB.SaveChanges();
                            response.Successfully = true;
                            response.Code = 201;
                            response.Message = "Inserción del Contacto realizado con éxito.";
                            response.Result = "Successfully";
                            transaction.Commit();
                            //Opcion de envio correo al crear Administrador
                        }
                        else
                        {
                            response.Successfully = false;
                            response.Code = 200;
                            response.Message = string.Format("Ya existe un Administrador con ese usuario {0} y con ese correo {1}", model.usuario_administrador, model.correo_administrador);
                            response.Result = null;
                        }
                    }
                    else
                    {
                        Admin = DB.Administrador.Where(x => x.id_admin == model.id_admin && x.usuario_administrador.ToUpper().Equals(model.usuario_administrador.ToUpper()) && x.correo_administrador.ToUpper().Equals(model.correo_administrador.ToUpper())).FirstOrDefault();
                        if (Admin != null)
                        {
                            DB.Entry(Admin).State = EntityState.Modified;
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
                            response.Message = "No se logró validar el Contacto o ya existe un Administrador con ese usuario " + model.usuario_administrador + " y con ese correo " + model.correo_administrador + "";
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