using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Modelo.Entidades;
using System.Web.Script.Serialization;

namespace SumateDos.Controllers
{
    public class LoginController : Controller
    {
        private string cadenaConexion = "Data Source=SUMATEPROD;Persist Security Info=True;User ID=INS;Password=INS;Unicode=True";

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetLogin(string pUsuario,string pPass)
        {
            try
            {
                bool res = EventosBLL.GetLogin(cadenaConexion,pUsuario,pPass);
                return Json(res,JsonRequestBehavior.AllowGet);
            }


            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
