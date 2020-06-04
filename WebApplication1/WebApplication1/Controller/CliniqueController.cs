using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Controller
{

    [ApiController]

    public class CliniqueController : ControllerBase
    {
        [Route("api/clinique/get")]
        [HttpGet]

        public IEnumerable<Doctor> Get()
        {
            var db = new CodeFirstContext();
            var doc = db.Doctor.ToList();

            return doc;
        }

        [Route("api/clinique/insert")]
        [HttpPost]
        public IActionResult Insert(DoctorRequest request)
        {
            var db = new CodeFirstContext();
            var doctor = new Doctor()
            {
                IdDoctor = request.IdDoctor,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };
            db.Doctor.Add(doctor);
            db.SaveChanges();

            return StatusCode(201, doctor);
        }

        [Route("api/clinique/delete")]
        [HttpPost]
        public IActionResult Delete(DoctorId request)
        {
            var db = new CodeFirstContext();

            db.Remove(db.Doctor.Find(request.IdDoctor));
            db.SaveChanges();

            return StatusCode(201, "Doktor został usunięty");
        }

        [Route("api/clinique/update")]
        [HttpPost]

        public IActionResult Update(DoctorRequest request)
        {
            var db = new CodeFirstContext();
            var doctor = new Doctor()
            {
                IdDoctor = request.IdDoctor,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            //db.Doctor.Find(request.IdDoctor);
            db.Doctor.Update(doctor);
            db.SaveChanges();

            return StatusCode(201, "Dane zaktualizowane");
        }
    }
}

