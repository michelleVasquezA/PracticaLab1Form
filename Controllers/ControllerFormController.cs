using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PracticaLab1Form.Models; //AGREGAMOS

namespace PracticaLab1Form.Controllers
{
    
    public class ControllerFormController : Controller
    {
        private readonly ILogger<ControllerFormController> _logger;

        public ControllerFormController(ILogger<ControllerFormController> logger)
        {
            _logger = logger;
        }

        public IActionResult VistaForm()
        {
            return View();
        }

[HttpPost]  //EL METODO POST DEL HTTP
        public IActionResult CalcularEdad(Persona objPersona)
        {
            string nom=null, ape=null;
            int anioActual=0, anioNacimiento=0, edad =0;

            nom = objPersona.nombre;
            ape = objPersona.apellido;
            anioActual = objPersona.anioActual;
            anioNacimiento = objPersona.anioNacimiento;

            //calculamos la edad
            if(nom != null ||ape != null){ //validacion que debe si o si completar con su nombre
                if(anioActual != 0 || anioNacimiento != 0){ // los años no pueden ser 0
                    edad = anioActual - anioNacimiento;
                }
            }

            ViewData["Message1"] = "La edad de "+ nom + " " + ape;
            ViewData["Message2"] = "es: " + edad;
           //para realizar el primer commit

            return View("VistaForm");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}