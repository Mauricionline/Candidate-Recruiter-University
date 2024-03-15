using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candidate_Recruiter.Models;

namespace Candidate_Recruiter.Controllers
{
    public class ReclutadoraController : Controller
    {
        private Reclutadora reclutadora = Reclutadora.GetReclutadora();
        private List<Candidato> candidatos = new List<Candidato>();
        private List<Puesto> puestos = new List<Puesto>();
        public ReclutadoraController()
        {
            if (CandidatosCrud.Candidatos.Count == 0) {
                Agregar10Candidatos();
                foreach (var item in candidatos)
                {
                    CandidatosCrud.AgregarCandidato(item);
                }
            }

            if(PuestosCrud.Puestos.Count == 0)
            {
                Agregar5Puestos();
                foreach (var item in puestos)
                {
                    PuestosCrud.AgregarPuesto(item);
                }
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CandidatosForm()
        {
            return View();
        }

        public IActionResult ProcessCandidatosForm()
        {
            CandidatosCrud.AgregarCandidato(new Candidato()
            {
                Cedula = Request.Form["cedula"],
                Nombre = Request.Form["nombre"],
                Correo = Request.Form["correo"],
                AspiracionSalarialMinima = Double.Parse(Request.Form["salario"])
            });

            return RedirectToAction("MessageAfterProcessing");
        }

        public IActionResult MessageAfterProcessing()
        {
            return View();
        }

        public IActionResult PuestosForm()
        {
            return View();
        }

        public IActionResult ProcessPuestosForm()
        {
            PuestosCrud.AgregarPuesto(new Puesto()
            {
                Codigo = Request.Form["codigo"],
                Nombre = Request.Form["puesto"],
                Salario = Double.Parse(Request.Form["salario"]),
                Status = Request.Form["status"]
            });

            return RedirectToAction("MessageAfterProcessing");
        }

        public IActionResult ViewCandidatos()
        {
            var candidatos = from candidato in CandidatosCrud.Candidatos
                             select candidato;

            ViewBag.mensaje = CandidatosCrud.Candidatos.Count > 0 ? "" : "No hay ningun candidato registrado";

            return View(candidatos);
        }

        public IActionResult ViewPuestos()
        {
            var puestos = from puesto in PuestosCrud.Puestos
                          select puesto;

            ViewBag.mensaje = PuestosCrud.Puestos.Count > 0 ? "" : "No hay ningun puesto registrado";

            return View(puestos);
        }

        public IActionResult EditPuesto(int posicion)
        {
            Puesto puesto = PuestosCrud.Puestos[posicion];
            ViewBag.posicion = posicion;
            return View(puesto);
        }

        public IActionResult ProcessEditPuesto()
        {
            int posicion = int.Parse(Request.Form["posicion"]);

            PuestosCrud.EditarPuesto(posicion, Double.Parse(Request.Form["salario"]), Request.Form["Status"]);

            // Desencadenamiento del patron observer
            reclutadora.VerificarStatusDePuesto(PuestosCrud.Puestos[posicion]);

            return RedirectToAction("ViewPuestos");
        }

        public IActionResult SuscripcionPuesto(int posicion)
        {
            var puestos = from puesto in reclutadora.GetPuestosNoSuscritos(CandidatosCrud.Candidatos[posicion].Cedula)
                          select puesto;

            ViewBag.posicion = posicion;
            ViewBag.mensaje = reclutadora.GetPuestosNoSuscritos(CandidatosCrud.Candidatos[posicion].Cedula).Count > 0 ? "" : "Al parecer el candidato esta suscrito a todos los puestos";

            return View(puestos);
        }

        public IActionResult ProcessSuscripcion(string codigo, int posicion)
        {
            Puesto puesto = PuestosCrud.BuscarPuestoPorCodigo(codigo);

            // Si el candidato se suscribe a un determinado puesto y el mismo esta vacante al momento de suscribirse
            // tambien se le mandara el correo
            reclutadora.Suscribir(CandidatosCrud.Candidatos[posicion], puesto);
            reclutadora.VerificarStatusDePuesto(puesto);
            
            return RedirectToAction("ViewCandidatos");
        }

        public IActionResult DesuscripcionPuesto(int posicion)
        {
            var puestos = from puesto in reclutadora.GetPuestosSuscritos(CandidatosCrud.Candidatos[posicion].Cedula)
                          select puesto;

            ViewBag.posicion = posicion;
            ViewBag.mensaje = reclutadora.GetPuestosSuscritos(CandidatosCrud.Candidatos[posicion].Cedula).Count > 0 ? "" : "Este candidato no esta suscrito a ningun puesto";

            return View(puestos);
        }

        public IActionResult CandidatosPuesto(string codigo)
        {
            var res = reclutadora.GetCandidatosPuesto(codigo);

            return View(res);
        }

        public IActionResult ProcessDesuscripcion(string codigo, int posicion)
        {
            Puesto puesto = PuestosCrud.BuscarPuestoPorCodigo(codigo);
            reclutadora.Desuscribir(CandidatosCrud.Candidatos[posicion], puesto);
            return RedirectToAction("ViewCandidatos");
        }


        public void Agregar5Puestos()
        {
            puestos.Add(new Puesto() { Nombre = "Backend C# Developer", Codigo = "1", Salario = 5000, Status = "Vacante" });

            puestos.Add(new Puesto() { Nombre = "Frontend Developer", Codigo = "2", Salario = 4800, Status = "Vacante" });

            puestos.Add(new Puesto() { Nombre = "Software Engineer", Codigo = "3", Salario = 5500, Status = "Vacante" });

            puestos.Add(new Puesto() { Nombre = "Data Scientist", Codigo = "4", Salario = 6000, Status = "Vacante" });

            puestos.Add(new Puesto() { Nombre = "DevOps Engineer", Codigo = "5", Salario = 5800, Status = "Vacante" });
        }

        public void Agregar10Candidatos()
        {
            // Agregar candidatos de ejemplo
            candidatos.Add(new Candidato
            {
                Cedula = "123456789",
                Nombre = "María García",
                Correo = "maria.garcia@example.com",
                AspiracionSalarialMinima = 2000
            });

            candidatos.Add(new Candidato
            {
                Cedula = "987654321",
                Nombre = "Carlos Fernández",
                Correo = "cfernandez@example.com",
                AspiracionSalarialMinima = 1800
            });

            candidatos.Add(new Candidato
            {
                Cedula = "456789123",
                Nombre = "Ana Rodríguez",
                Correo = "anarod@example.com",
                AspiracionSalarialMinima = 2200
            });

            // Agregar otros candidatos de forma similar
            candidatos.Add(new Candidato
            {
                Cedula = "654321987",
                Nombre = "Juan López",
                Correo = "juan.lopez@example.com",
                AspiracionSalarialMinima = 1900
            });

            candidatos.Add(new Candidato
            {
                Cedula = "789123456",
                Nombre = "Laura Martínez",
                Correo = "laura.martinez@example.com",
                AspiracionSalarialMinima = 2100
            });

            candidatos.Add(new Candidato
            {
                Cedula = "321654987",
                Nombre = "Pedro Díaz",
                Correo = "pdiaz@example.com",
                AspiracionSalarialMinima = 1950
            });

            candidatos.Add(new Candidato
            {
                Cedula = "135792468",
                Nombre = "Sofía López",
                Correo = "slo@example.com",
                AspiracionSalarialMinima = 2050
            });

            candidatos.Add(new Candidato
            {
                Cedula = "246813579",
                Nombre = "Miguel González",
                Correo = "mgonzalez@example.com",
                AspiracionSalarialMinima = 1980
            });

            candidatos.Add(new Candidato
            {
                Cedula = "9876543210",
                Nombre = "Elena Sánchez",
                Correo = "elenas@example.com",
                AspiracionSalarialMinima = 2250
            });

            candidatos.Add(new Candidato
            {
                Cedula = "123098765",
                Nombre = "David Pérez",
                Correo = "david.perez@example.com",
                AspiracionSalarialMinima = 1800
            });
        }
    }
}