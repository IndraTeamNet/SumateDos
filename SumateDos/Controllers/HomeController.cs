using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SumateDos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        /*
        [HttpGet]
        public string GetEventos()
        {
            try
            {
                string oraSQLCommand = "Select e.evento_asociado AS EventoAsociado, " +
                                       " e.estado, " +
                                       " CASE e.estado " +
                                         " WHEN 'C' THEN " +
                                          " 'COMENZARÁ' " +
                                         " WHEN 'A' THEN " +
                                          " 'ABIERTO' " +
                                         " WHEN 'T' THEN " +
                                          " 'TERMINADO' " +
                                       " End AS Estado2, " +
                                       " TRUNC(fecha_termino - SYSDATE) || ' / ' || " +
                                       " epoch_delta_date(fecha_termino - SYSDATE - " +
                                                        " TRUNC(fecha_termino - SYSDATE)) Tiempo, " +
                                       " (SELECT AG_NME FROM AGENC AG WHERE AG.AG_ID = E.agencia) NombreAgencia, " +
                                       " a.barrio AS Barrio, " +
                                       " a.localidad AS Localidad, " +
                                       " e.municipio AS Municipio, " +
                                       " UPPER(REPLACE(e.numero_placa, CHR(10), '')) Placa, " +
                                       " TO_CHAR(e.fecha_registro, 'DD/MM/YYYY HH24:mi:ss') FechaCargue, " +
                                       " TO_CHAR(e.fecha_inicio, 'DD/MM/YYYY HH24:mi:ss') FechaInicio, " +
                                       " TO_CHAR(e.fecha_termino, 'dd/MM/YYYY HH24:mi:ss') FechaTermino, " +
                                       " '' AS Tipo, " +
                                       " e.empresa AS Colaborador, " +
                                       " e.responsable AS Responsable, " +
                                       " e.NUMERO_CONTACTO_CODENSA AS NumContacto, " +
                                       " e.CEDULA_RESPONSABLE AS Cedula, " +
                                       " e.direccion AS Direccion, " +
                                       " e.Tipo_Trabajo AS TipoTrabajo, " +
                                       " ev.X_CORD AS coordX, " +
                                       " ev.y_cord AS coordY, " +
                                       " '' AS Origen " +
                                  " from eventos e, aeven a, event ev " +
                                 " where e.ESTADO in ('A', 'T') " +
                                "    and e.fecha_termino > to_Date('27/11/2019 00:00', 'DD/MM/YYYY HH24:MI') " +
                                   " and e.fecha_inicio<to_Date('27/11/2019 23:59', 'DD/MM/YYYY HH24:MI') " +
                                   " and a.num_1 = e.evento_asociado " +
                                   " and a.eid = ev.eid " +
                                   " and UPPER(e.empresa) like UPPER('%deltec%') ";

                string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["oraConSumate"].ConnectionString;

                DataSet dsEventos = EventosBLL.GetEventos(cadenaConexion, oraSQLCommand);
                var daresult = DataSetToJSON(dsEventos);
                daresult = daresult.Substring(10, daresult.Length - 17) + "]";
                return daresult;
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
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        */
    }
    
}