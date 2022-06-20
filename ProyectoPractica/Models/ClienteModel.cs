using System.ComponentModel.DataAnnotations;

namespace ProyectoPractica.Models
{
    public class ClienteModel
    {
        //Definimos el modelo que necesitaremos para la captura de informacion, con sus validaciones y requerimientos.
        //Si algun requerimiento no se cumple se retornara un mensaje de error personalizado
        public int idCliente { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [MaxLength(50)]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóúñÑ ]*$", ErrorMessage = "Solo se letras")]
        public string? nombre_cliente { get; set; }

        [Required(ErrorMessage = "El campo apellido paterno es obligatorio")]
        [MaxLength(50)]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóúñÑ ]*$", ErrorMessage = "Solo se letras")]
        public string? primer_apellidocliente { get; set; }

        [MaxLength(50)]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóúñÑ ]*$", ErrorMessage = "Solo se letras")]
        public string? segundo_apellidocliente { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "La calle es obligatoria")]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóúñÑ0-9 ]*$", ErrorMessage = "Solo se letras y numeros")]
        public string? calle { get; set; }

        [Required(ErrorMessage = "El numero del domicilio es obligatorio")]
        [MaxLength(6)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Debe contener solo numeros")]
        public string? numero { get; set; }

        [Required(ErrorMessage = "La colonia es obligatoria")]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóúñÑ0-9 ]*$", ErrorMessage = "Solo se letras y numeros")]
        [MaxLength(50)]
        public string? colonia { get; set; }

        [Required(ErrorMessage = "El codigo postal es obligatorio")]
        [MaxLength(5)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Debe contener solo numeros")]
        public string? codigo_postal { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio")]
        [MaxLength(10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Debe contener solo numeros")]
        public string? telefono { get; set; }

        [Required(ErrorMessage = "El RFC es obligatorio")]
        [RegularExpression("^[A-ZÑ0-9 ]*$", ErrorMessage = "Solo se letras y numeros")]
        [MaxLength(13)]
        [MinLength(12, ErrorMessage = "Introduzca un RFC Valido")]
        public string? rfc_cliente { get; set; }

        [MaxLength(10, ErrorMessage = "Seleccione un estatus valido.")]
        public string? estatus { get; set; }

        [Required(ErrorMessage = "Los documentos son obligatorios es obligatorio")]
        public string? documentos { get; set; }
        
        [MinLength(10, ErrorMessage = "Debe contener observaciones obligatorias mayor a 15 caracteres.")]
        public string? observaciones { get; set; }
    }
}
