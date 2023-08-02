using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcAssignment.Entities;
using MvcAssignment.Model;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace MvcAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly DBContext DBContext;

        public PatientController(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }

        [HttpGet("GetPatient")]
        public async Task<ActionResult<List<PatientdetailDTO>>>GetPatient()
        {
            var pat = await DBContext.Patientdetails.Select(
                s => new PatientdetailDTO
                {
                    patientid = s.patientid,
                    PatientCode = s.PatientCode,
                    RegistrationDate = s.RegistrationDate,
                    FName = s.FName,
                    LastName = s.LastName,
                    Gender = s.Gender,
                    Age = s.Age,
                    BOD = s.BOD,
                    BloodGroup = s.BloodGroup,
                    Address = s.Address,
                    Email = s.Email,
                    Mobile = s.Mobile,
                    IsActive = s.IsActive,

                }
                ).Take(10).ToListAsync();

            if (pat.Count < 0)
            {
                return NotFound();

            }
            else
            {
                return pat;
            }


        }
        
        [HttpGet("GetPatientbyid")]

        public async Task<ActionResult<PatientdetailDTO>> GetPatientbyid(int patientid)
        {
            var pat = await DBContext.Patientdetails.Select(
                s => new PatientdetailDTO
                {
                    patientid = s.patientid,
                    PatientCode = s.PatientCode,
                    RegistrationDate = s.RegistrationDate,
                    FName = s.FName,
                    LastName = s.LastName,
                    Gender = s.Gender,
                    Age = s.Age,
                    BOD = s.BOD,
                    BloodGroup = s.BloodGroup,
                    Address = s.Address,
                    Email = s.Email,
                    Mobile = s.Mobile,
                    IsActive = s.IsActive,

                }
                ).FirstOrDefaultAsync(s => s.patientid == patientid);

            if (pat == null)
            {
                return NotFound();

            }
            else
            {
                return pat;
            }
        }

        [HttpPost("InsertPatient")]

        public async Task<HttpStatusCode> InsertPatient([FromForm] InsertpatientDTO Patdetail)
        {
            var entity = new Patientdetail();
            {
                entity.patientid = Patdetail.patientid;
                entity.PatientCode = Patdetail.PatientCode;
                entity.RegistrationDate = Patdetail.RegistrationDate;
                entity.FName = Patdetail.FName;
                entity.LastName = Patdetail.LastName;
                entity.Gender = Patdetail.Gender;
                entity.Age = Patdetail.Age;
                entity.BOD = Patdetail.BOD;
                entity.BloodGroup = Patdetail.BloodGroup;
                entity.Address = Patdetail.Address;
                entity.Email = Patdetail.Email;
                entity.Mobile = Patdetail.Mobile;
                entity.IsActive = true;

            }
            DBContext.Patientdetails.Add(entity);
            await DBContext.SaveChangesAsync();

            return (HttpStatusCode.Created);
        }

        [HttpPut("UpdatePatient")]
        public async Task<HttpStatusCode> UpdatePatient([FromForm] InsertpatientDTO upatient )
        {
            var entity = await DBContext.Patientdetails.FirstOrDefaultAsync
                (s=>s.patientid==upatient.patientid);
            {
                entity.patientid=upatient.patientid;
                entity.PatientCode=upatient.PatientCode;
                entity.RegistrationDate=upatient.RegistrationDate;
                entity.FName=upatient.FName;
                entity.LastName=upatient.LastName;
                entity.Gender=upatient.Gender;
                entity.Age=upatient.Age;
                entity.BOD=upatient.BOD;
                entity.BloodGroup=upatient.BloodGroup;
                entity.Address=upatient.Address;
                entity.Email=upatient.Email;
                entity.Mobile=upatient.Mobile;

                await DBContext.SaveChangesAsync();
                return(HttpStatusCode.Created);

            }
            
        }

        [HttpPut("DeletePatient")]
        public async Task<HttpStatusCode> DeletePatient(int patientid)
        {
            var entity = DBContext.Patientdetails.FirstOrDefault(s=>s.patientid==patientid);
            {
                entity.IsActive = false;

                await DBContext.SaveChangesAsync();

                return(HttpStatusCode.Created);
            }
        }



        

    }
}
