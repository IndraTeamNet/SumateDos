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

        [HttpGet]
        public JsonResult GetUsuario(String pUsuario,string pPass)
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

        public string DataSetToJSON(DataSet ds)
        {

            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (DataTable dt in ds.Tables)
            {
                object[] arr = new object[dt.Rows.Count + 1];

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    arr[i] = dt.Rows[i].ItemArray;
                }

                dict.Add(dt.TableName, arr);
            }

            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Serialize(dict);
        }

    }
}
