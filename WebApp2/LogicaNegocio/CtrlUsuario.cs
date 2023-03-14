using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoSM.AccesoDatos;
using System.Collections;

namespace LogicaNegocio
{
    public class CtrlUsuario
    {
        RESERVAMEEntities DBContext = new RESERVAMEEntities();

        public string getFullName(string pUsername)
        {
            try
            {
                var query = (from c in DBContext.USUARIO
                             where c.cUsername.Equals(pUsername)
                             select new
                             {
                                 cFullname = c.cFullname
                             }).FirstOrDefault();
                if (query == null)
                {
                    return "";
                }
                else
                {
                    return query.cFullname;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
        }
        //metodo para buscar
        public IList BuscarUsuario(string pFullname)
        {
            try
            {
                var query = (from c in DBContext.USUARIO
                             where c.cFullname.Contains(pFullname)
                             orderby c.cFullname
                             select new
                             {
                                 cUsername = c.cUsername,
                                 cFullname = c.cFullname,
                                 cCelular = c.cCelular,
                                 cEmail = c.cEmail,
                                 dFechaNac = c.dFechaNac,
                             }).Take(10).ToList().Select(x => new
                             {
                                 cUsername = x.cUsername,
                                 cFullname = x.cFullname,
                                 cCelular = x.cCelular,
                                 cEmail = x.cEmail,
                                 dFechaNac = string.Format("{0:dd/MM/yyyy}", x.dFechaNac),
                             }).ToList();
                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        //metodo para registro
        public int RegistrarUsuario(string pUsername, string pPassword, string pFullname, string pCelular, string pEmail, DateTime pFechaNac)
        {
            try
            {
                USUARIO query = new USUARIO();
                query.cUsername = pUsername;
                query.cPassword = pPassword;
                query.cFullname = pFullname;
                query.cCelular = pCelular;
                query.cEmail = pEmail;
                query.dFechaNac = pFechaNac;
                DBContext.USUARIO.Add(query);
                DBContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        
    }
}
