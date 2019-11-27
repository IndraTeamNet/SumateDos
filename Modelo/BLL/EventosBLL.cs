using AccesoADatos.DAL;
using System.Data;
using System.Data.OracleClient;


namespace Modelo.Entidades
{
    public class EventosBLL
    {
        public static DataSet GetEventos(string pCadenaConexion, string pOraSQLCommand)
        {
            try
            {
                OracleParameter oraParam = new OracleParameter("SQL_DINAMICO", OracleType.VarChar);
                oraParam.Value = pOraSQLCommand;
                oraParam.Direction = ParameterDirection.Input;
                return EventosDAL.GetEventos(pCadenaConexion, "PKG_ADMINISTRACION.PR_GET_EVENTOS", oraParam);
            }
            catch (OracleException ex)
            {
                throw ex;
            }
        }
    }
}
