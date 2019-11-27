using System.Data;
using System.Data.OracleClient;

namespace AccesoADatos.DAL
{
    public class EventosDAL
    {
        public static DataSet GetEventos(string pCadenaConexion, string pNombreSP, OracleParameter pParam)
        {
            try
            {
                using (OracleConnection OraCon = new OracleConnection(pCadenaConexion))
                {
                    DataSet dsEventos = new DataSet();
                    OracleCommand oraCmd = new OracleCommand(pNombreSP, OraCon);
                    OracleDataAdapter oraADAP = new OracleDataAdapter(oraCmd);
                    oraCmd.CommandType = CommandType.StoredProcedure;

                    if (pParam != null)
                        oraCmd.Parameters.Add(pParam);

                    oraCmd.Parameters.Add(new OracleParameter("RETORNO", OracleType.Cursor)).Direction = ParameterDirection.Output;
                    oraADAP.Fill(dsEventos);
                    return dsEventos;
                }
            }
            catch (OracleException ex)
            {
                throw ex;
            }
        }
    }
}