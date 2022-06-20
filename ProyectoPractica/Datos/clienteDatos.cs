using ProyectoPractica.Models;
using System.Data.SqlClient;
using System.Data;


namespace ProyectoPractica.Datos
{
    public class clienteDatos
    {
        public List<ClienteModel> ListadoGeneral()
        {
            var oLista = new List<ClienteModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cdm = new SqlCommand("clientes_listadogeneral", conexion);
                cdm.CommandType = CommandType.StoredProcedure;
                using (var dr = cdm.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ClienteModel()
                        {
                            idCliente = Convert.ToInt32(dr["idCliente"]),
                            nombre_cliente = dr["nombre_cliente"].ToString(),
                            primer_apellidocliente = dr["primer_apellidocliente"].ToString(),
                            segundo_apellidocliente = dr["segundo_apellidocliente"].ToString(),
                            calle = dr["calle"].ToString(),
                            numero = dr["numero"].ToString(),
                            colonia = dr["colonia"].ToString(),
                            codigo_postal = dr["codigo_postal"].ToString(),
                            telefono = dr["telefono"].ToString(),
                            rfc_cliente = dr["rfc_cliente"].ToString(),
                            estatus = dr["estatus"].ToString(),
                            documentos = dr["documentos"].ToString(),
                            observaciones = dr["observaciones"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }

        public ClienteModel Obtener(int idCliente)
        {
            var oCliente = new ClienteModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cdm = new SqlCommand("clientes_listadoespecifico", conexion);
                cdm.Parameters.AddWithValue("idCliente", idCliente);
                cdm.CommandType = CommandType.StoredProcedure;
                using (var dr = cdm.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCliente.idCliente = Convert.ToInt32(dr["idCliente"]);
                        oCliente.nombre_cliente = dr["nombre_cliente"].ToString();
                        oCliente.primer_apellidocliente = dr["primer_apellidocliente"].ToString();
                        oCliente.segundo_apellidocliente = dr["segundo_apellidocliente"].ToString();
                        oCliente.calle = dr["calle"].ToString();
                        oCliente.numero = dr["numero"].ToString();
                        oCliente.colonia = dr["colonia"].ToString();
                        oCliente.codigo_postal = dr["codigo_postal"].ToString();
                        oCliente.telefono = dr["telefono"].ToString();
                        oCliente.rfc_cliente = dr["rfc_cliente"].ToString();
                        oCliente.estatus = dr["estatus"].ToString();
                        oCliente.documentos = dr["documentos"].ToString();
                        oCliente.observaciones = dr["observaciones"].ToString();
                    }
                }
            }
            return oCliente;
        }

        public bool Guardar(ClienteModel oCliente)
        {
            bool resp;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cdm = new SqlCommand("clientes_guardar", conexion);
                    cdm.Parameters.AddWithValue("nombre_cliente", oCliente.nombre_cliente);
                    cdm.Parameters.AddWithValue("primer_apellidocliente", oCliente.primer_apellidocliente);
                    cdm.Parameters.AddWithValue("segundo_apellidocliente", oCliente.segundo_apellidocliente);
                    cdm.Parameters.AddWithValue("calle", oCliente.calle);
                    cdm.Parameters.AddWithValue("numero", oCliente.numero);
                    cdm.Parameters.AddWithValue("colonia", oCliente.colonia);
                    cdm.Parameters.AddWithValue("codigo_postal", oCliente.codigo_postal);
                    cdm.Parameters.AddWithValue("telefono", oCliente.telefono);
                    cdm.Parameters.AddWithValue("rfc_cliente", oCliente.rfc_cliente);
                    cdm.Parameters.AddWithValue("estatus", "Enviado");
                    cdm.Parameters.AddWithValue("documentos", oCliente.documentos);
                    cdm.Parameters.AddWithValue("observaciones", "Sin Obs");
                    cdm.CommandType = CommandType.StoredProcedure;
                    cdm.ExecuteNonQuery();
                }
                resp = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                resp = false;
            }
            return resp;
        }

        public bool EditarAutorizado(ClienteModel oCliente)
        {
            bool resp;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cdm = new SqlCommand("clientes_cambioEstatusAutorizado", conexion);
                    cdm.Parameters.AddWithValue("idCliente", oCliente.idCliente);
                    cdm.Parameters.AddWithValue("nombre_cliente", oCliente.nombre_cliente);
                    cdm.Parameters.AddWithValue("estatus", oCliente.estatus);
                    cdm.Parameters.AddWithValue("observaciones", oCliente.observaciones);
                    cdm.CommandType = CommandType.StoredProcedure;
                    cdm.ExecuteNonQuery();
                }
                resp = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                resp = false;
            }
            return resp;
        }
    }
}
