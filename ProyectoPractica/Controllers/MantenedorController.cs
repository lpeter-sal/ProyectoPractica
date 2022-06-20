using Microsoft.AspNetCore.Mvc;

using ProyectoPractica.Datos;
using ProyectoPractica.Models;


namespace ProyectoPractica.Controllers
{
    public class MantenedorController : Controller
    {
        //Creamos una interfaz/modelo en base a nuestro Modelo de datos
        clienteDatos _ClienteDatos = new clienteDatos();

        public IActionResult ListadoGeneral(){
            //Metodo paramMostrar el Listado General de los clientes
            var oLista = _ClienteDatos.ListadoGeneral();
            return View(oLista);
        }

        public IActionResult Guardar(){
            //Metodo solo devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ClienteModel oCliente){
            //Guardar en la base de datos
            if (!ModelState.IsValid){
                return View();
            } else{
                var resp = _ClienteDatos.Guardar(oCliente);
                if (resp){
                    TempData["Mensaje"] = "El Cliente se guardo correctamente.";
                    return RedirectToAction("ListadoGeneral");
                }else {
                    TempData["Mensaje"] = "Ya existe un cliente con ese RFC, Verifica tu RFC.";
                    return View();
                }
            }
        }

        public IActionResult Editar(int idCliente){
            //Metodo solo devuelve la vista
            var oClienteUnico = _ClienteDatos.Obtener(idCliente);
            return View(oClienteUnico);
        }

        [HttpPost]
        public IActionResult Editar(ClienteEditModel oCliente){
            //Guardar en la base de datos

            if (!ModelState.IsValid){
                return View();
            } else{
                var resp = _ClienteDatos.EditarAutorizado(oCliente);
                if (resp){
                    TempData["Mensaje"] = "El Cliente fue evaluado correctamente.";
                    return RedirectToAction("ListadoGeneral");
                } else{
                    return View();
                }
            }
        }

        public IActionResult InformacionCliente(int idCliente)
        {
            //Metodo solo devuelve la vista
            var oClienteUnico = _ClienteDatos.Obtener(idCliente);
            return View(oClienteUnico);
        }
    }
}
