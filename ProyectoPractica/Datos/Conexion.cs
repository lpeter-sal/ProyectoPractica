using System.Data.SqlClient;

namespace ProyectoPractica.Datos
{
    public class Conexion
    {

        private string cadenaSQL = string.Empty;

        //Constructor
        public Conexion(){
            //construir la variable para el builder
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            //Obtener la cadena de conexion que se encuentra en el archivo appsettings.json y lo guardamos en cadenaSQL
            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string getCadenaSQL(){
            return cadenaSQL;

        }


    }
}
