using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Patients.Data;
using Microsoft.EntityFrameworkCore;
using Web_API_Patients.Data.Entities;

namespace Web_API_Patients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class PatientController : ControllerBase
    {
        private readonly MyDatabaseDbContext _MyDatabaseDbContext;

        public PatientController(MyDatabaseDbContext myDatabaseDbContext) //small case
        {
            _MyDatabaseDbContext = myDatabaseDbContext; //small case
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var Patients = await _MyDatabaseDbContext.Patients.ToListAsync();

            
            return Ok(Patients);
        }

        [HttpGet]
        [Route("get-patients-by-id")]
        public async Task<IActionResult> GetPatientsByIdAsync(int id)
        {
            var Patients = await _MyDatabaseDbContext.Patients.FindAsync(id);
            return Ok(Patients);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Patients newpatients)
        {
            _MyDatabaseDbContext.Patients.Add(newpatients);
            await _MyDatabaseDbContext.SaveChangesAsync();
            return Created($"patients/get-patients-by-id?id={newpatients.Id}", newpatients);
        }

        [HttpPut]

        public async Task<IActionResult> PutAsync(Patients patientsToUpdate)
        {
            _MyDatabaseDbContext.Patients.Update(patientsToUpdate);
            await _MyDatabaseDbContext.SaveChangesAsync();
            return NoContent();
        }
        [Route("{id}")]
        [HttpDelete]

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var patientsToDelete = await _MyDatabaseDbContext.Patients.FindAsync(id);
            if (patientsToDelete == null)
            {
                return NotFound();
            }
            _MyDatabaseDbContext.Patients.Remove(patientsToDelete);
            await _MyDatabaseDbContext.SaveChangesAsync();
            return NoContent();
        }



    }
}