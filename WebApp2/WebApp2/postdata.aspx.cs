using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using System.Collections;
using System.Web.Services;

namespace WebApp2
{
    public partial class postdata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        //buscar usuario
        [WebMethod]

        public static IList BuscarUsuario(string pFullname)
        {
            try
            {
                CtrlUsuario negocio = new CtrlUsuario();
                return negocio.BuscarUsuario(pFullname);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //registro dato
        [WebMethod]

        public static int RegistrarUsuario(string pUsername, string pPassword, string pFullname, string pCelular, string pEmail, DateTime pFechaNac)
        {
            try
            {
                CtrlUsuario negocio = new CtrlUsuario();
                return negocio.RegistrarUsuario(pUsername, pPassword, pFullname, pCelular, pEmail, pFechaNac);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}