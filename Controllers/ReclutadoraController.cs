using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candidate_Recruiter.Models;
using Candidate_Recruiter.DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Candidate_Recruiter.Controllers
{
    public class ReclutadoraController : Controller
    {
        //private Reclutadora reclutadora = Reclutadora.GetReclutadora();
        private List<Candidato> candidatos = new List<Candidato>();
        private List<Puesto> puestos = new List<Puesto>();
        private readonly ICandidatoRepository _candidatoRepository;
        private readonly IPuestoRepository _puestoRepository;
        private readonly ICandidatoPuestoRepository _candidatoPuestoRepository;
        public ReclutadoraController(IPuestoRepository puestoRepository, ICandidatoRepository candidatoRepository, ICandidatoPuestoRepository candidatoPuestoRepository)
        {
            _puestoRepository = puestoRepository;
            _candidatoRepository = candidatoRepository;
            _candidatoPuestoRepository = candidatoPuestoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CandidatosForm()
        {
            return View();
        }

        public async Task<IActionResult> ProcessCandidatosForm()
        {
            await _candidatoRepository.Add(new Candidato()
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

        public async Task<IActionResult> ProcessPuestosForm()
        {
            await _puestoRepository.Add(new Puesto()
            {
                Codigo = Request.Form["codigo"],
                Nombre = Request.Form["puesto"],
                Salario = Double.Parse(Request.Form["salario"]),
                Status = Request.Form["status"]
            });

            return RedirectToAction("MessageAfterProcessing");
        }

        public async Task<IActionResult> ViewCandidatos()
        {
            //var candidatos = from candidato in CandidatosCrud.Candidatos
            //                 select candidato;

            var candidatos = await _candidatoRepository.GetAll().ToListAsync();

            ViewBag.mensaje = candidatos.Count > 0 ? "" : "No hay ningun candidato registrado";

            return View(candidatos);
        }

        public async Task<IActionResult> ViewPuestos()
        {
            //var puestos = from puesto in PuestosCrud.Puestos
            //              select puesto;

            var puestos = await _puestoRepository.GetAll().ToListAsync();

            ViewBag.mensaje = puestos.Count > 0 ? "" : "No hay ningun puesto registrado";

            return View(puestos);
        }

        public async Task<IActionResult>EditPuesto(Guid puestoId)
        {
            var puesto = await _puestoRepository.GetAll().Where(x=> x.Id == puestoId).FirstOrDefaultAsync();
            ViewBag.puestoId = puestoId;
            return View(puesto);
        }

        public async Task<IActionResult> ProcessEditPuesto()
        {
            string codigo = (Request.Form["codigo"]);

            var found = await _puestoRepository.BuscarPorCodigo(codigo);
            found.Salario = Double.Parse(Request.Form["salario"]);
            found.Status = Request.Form["Status"];

            return RedirectToAction("ViewPuestos");
        }

        public async Task<IActionResult> SuscripcionPuesto(Guid candidatoId)
        {
            var puestos = await _candidatoPuestoRepository.PuestosNoSuscritosPorCandidato(candidatoId);
            ViewBag.candidatoId = candidatoId;
            ViewBag.mensaje = puestos.Count > 0 ? "" : "Al parecer el candidato esta suscrito a todos los puestos";

            return View(puestos);
        }

        public async Task<IActionResult> ProcessSuscripcion(Guid puestoId, Guid candidatoId)
        {
            await _candidatoPuestoRepository.AddSubscripcion(new CandidatoPuesto { CandidatoId = candidatoId, PuestoId = puestoId });
            
            return RedirectToAction("ViewCandidatos");
        }

        public async Task<IActionResult> DesuscripcionPuesto(Guid candidatoId)
        {
            var puestos = await _candidatoPuestoRepository.PuestosPorCandidato(candidatoId);

            ViewBag.mensaje = puestos.Count > 0 ? "" : "Este candidato no esta suscrito a ningun puesto";
            ViewBag.candidatoId = candidatoId;

            return View(puestos);
        }

        public async Task<IActionResult> CandidatosPuesto(Guid puestoId)
        {
            var res = await _candidatoPuestoRepository.CandidatosPorPuesto(puestoId);

            return View(res);
        }

        public async Task<IActionResult> ProcessDesuscripcion(Guid puestoId, Guid candidatoId)
        {
            var found = await _candidatoPuestoRepository.GetAll().Where(x => x.CandidatoId == candidatoId && x.PuestoId == puestoId).FirstOrDefaultAsync();
            await _candidatoPuestoRepository.RemoveSubscripcion(found.Id);
            return RedirectToAction("ViewCandidatos");
        }
    }
}