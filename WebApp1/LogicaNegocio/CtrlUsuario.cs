using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoSM.AccesoDatos;
using System.Collections;

namespace CursoSM.LogicaNegocio
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
                if(query == null)
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
    }
}
