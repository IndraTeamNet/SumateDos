using System;
using System.Data;
using System.Data.OracleClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AccesoADatos.DAL
{
    public class EventosDAL
    {
        static byte[] Four = ASCIIEncoding.ASCII.GetBytes("quelityi");
        public static string clave = "rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5";

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

        public static bool GetLogin(string pCadenaConexion, string pUsuario, string pPass)
        {
            try
            {
                using (OracleConnection OraCon = new OracleConnection(pCadenaConexion))
                {
                    bool vIngresoCorrecto=false;

                    DataSet dsEventos = new DataSet();
                    OracleCommand oraCmd = new OracleCommand("select usr_id,pswrd from persl where usr_id='"+pUsuario+"'",OraCon);
                    OraCon.Open();
                    OracleDataReader oraDr= oraCmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable dt = new DataTable();
                    dt.Load(oraDr);

                    //dt.Rows[0]["usr_id"].ToString();
                    //string vPass=dt.Rows[0]["pswrd"].ToString();
                   

                    if(pUsuario == dt.Rows[0]["usr_id"].ToString())
                    {
                        vIngresoCorrecto = true;
                    }



                    return vIngresoCorrecto;
                }
            }
            catch (OracleException ex)
            {
                throw ex;
            }
        }


        /*
         *         Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes("quelityi")
        Dim EncryptionKey() As Byte = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5")
        Dim buffer() As Byte = Encoding.UTF8.GetBytes(texto)
        Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        Dim encrip As String
        des.Key = EncryptionKey
        des.IV = IV

        encrip = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length()))

        Return encrip
         */
      
        public static string Cifrar(string cadena)
        {
            byte[] llave; //Arreglo donde guardaremos la llave para el cifrado 3DES.
            byte[] arreglo = UTF8Encoding.UTF8.GetBytes(cadena); //Arreglo donde guardaremos la cadena descifrada.
            // Ciframos utilizando el Algoritmo MD5.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(clave));
            md5.Clear();
            //Ciframos utilizando el Algoritmo 3DES.
            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = llave;
            tripledes.IV = Four;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateEncryptor(); // Iniciamos la conversión de la cadena
            byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length); //Arreglo de bytes donde guardaremos la cadena cifrada.
            tripledes.Clear();
            return Convert.ToBase64String(resultado, 0, resultado.Length); // Convertimos la cadena y la regresamos.
        }

        public static string Descifrar(string cadena)
        {
            byte[] llave;
            byte[] arreglo = Convert.FromBase64String(cadena); // Arreglo donde guardaremos la cadena descovertida.
            // Ciframos utilizando el Algoritmo MD5.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(clave));
            md5.Clear();
            //Ciframos utilizando el Algoritmo 3DES.
            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = llave;
            tripledes.IV = Four;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateDecryptor();
            byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length);
            tripledes.Clear();
            string cadena_descifrada = UTF8Encoding.UTF8.GetString(resultado); // Obtenemos la cadena
            return cadena_descifrada; // Devolvemos la cadena
        }
    }
}