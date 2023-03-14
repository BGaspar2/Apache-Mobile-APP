using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoSM.AccesoDatos;
using System.Collections;

namespace LogicaNegocio
{
    public class CtrlRestaurante
    {
        RESERVAMEEntities DBContext = new RESERVAMEEntities();

        /** LISTA DE RESTAURANTES **/

        public IList ListaRestautantes()
        {
            try
            {
                var query = (from c in DBContext.RESTAURANTE
                             orderby c.cNombre
                             select new
                             {
                                 cNombre = c.cNombre,
                                 cDireccion = c.cDireccion,
                                 cTelefono = c.cTelefono

                             }).Take(10).ToList();
                return query;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
