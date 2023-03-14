﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using System.Web.Script.Serialization;

namespace WebApp2
{
    public partial class getLista : System.Web.UI.Page
    {
        public string retVal = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetNoStore();

            CtrlRestaurante negocio = new CtrlRestaurante();
            var lista = negocio.ListaRestautantes();

            var json = new JavaScriptSerializer();
            retVal = json.Serialize(lista);

        }
    }
}
