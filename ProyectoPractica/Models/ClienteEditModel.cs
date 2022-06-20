using System.ComponentModel.DataAnnotations;
namespace ProyectoPractica.Models
{
    public class ClienteEditModel
    {
        //Definimos el modelo que necesitaremos para la captura de informacion, con sus validaciones y requerimientos.
        //Si algun requerimiento no se cumple se retornara un mensaje de error personalizado
        public int idCliente { get; set; }

        public string? nombre_cliente { get; set; }

        public string? primer_apellidocliente { get; set; }

        public string? segundo_apellidocliente { get; set; }

        public string? calle { get; set; }

        public string? numero { get; set; }

        public string? colonia { get; set; }

        public string? codigo_postal { get; set; }

        public string? telefono { get; set; }

        public string? rfc_cliente { get; set; }

        [MaxLength(10, ErrorMessage = "Seleccione un estatus valido.")]
        public string? estatus { get; set; }

        public string? documentos { get; set; }

        [MinLength(10, ErrorMessage = "Debe contener observaciones obligatorias mayor a 15 caracteres.")]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóúñÑ0-9 ]*$", ErrorMessage = "Solo se letras y numeros")]
        public string? observaciones { get; set; }
    }
}
