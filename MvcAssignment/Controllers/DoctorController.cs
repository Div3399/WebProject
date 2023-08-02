using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcAssignment.Entities;
using MvcAssignment.Model;
using System.Net;

namespace MvcAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DBContext DBContext;

        public DoctorController(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }

        [HttpGet("GetDoctordetail")]

        public async Task<ActionResult<List<DoctordetailDTO>>> GetDoctordetail()
        {
            var doctor = await DBContext.Doctordetails.Select(
                s => new DoctordetailDTO
                {
                    DoctorID=s.DoctorID,
                    RegDate=s.RegDate,
                    FirstName=s.FirstName,
                    LastName=s.LastName,
                    Gender=s.Gender,
                    Email=s.Email,
                    BloodGroup=s.BloodGroup,
                    Mobile1=s.Mobile1,
                    Line1 =s.Line1,
                    IsActive=true,
                }
                ).ToListAsync();

            if (doctor.Count < 0)
            {
                return NotFound();

            }
            else
            {
                return doctor;
            }
        }

        [HttpGet("Doctorbyid")]
        public async Task<ActionResult<DoctordetailDTO>> Doctorbyid(int DoctorID)
        {
            var doc = await DBContext.Doctordetails.Select(
                s => new DoctordetailDTO
                { 
                    DoctorID=s.DoctorID,
                    RegDate=s.RegDate,
                    FirstName=s.FirstName,
                    LastName =s.LastName,
                    Gender=s.Gender,
                    BloodGroup=s.BloodGroup,
                    Email=s.Email,
                    Mobile1=s.Mobile1,
                    Line1=s.Line1,
                    IsActive=true,

                }
                ).FirstOrDefaultAsync(s => s.DoctorID == DoctorID);

            if (doc == null)
            {
                return NotFound();

            }
            else
            {
                return doc;
            }
        }

        [HttpPost("InsertDoctor")]
        public async Task<HttpStatusCode> InsertDoctor([FromForm] InsertDoctorDTO doc)
        {
            var dd = new Doctordetail();
            {
                dd.DoctorID = doc.DoctorID;   
                dd.RegDate = doc.RegDate; 
                dd.FirstName = doc.FirstName;
                dd.LastName = doc.LastName;
                dd.Gender = doc.Gender;
                dd.Email = doc.Email;
                dd.BloodGroup = doc.BloodGroup;
                dd.Mobile1 = doc.Mobile1;
                dd.Line1 = doc.Line1;
                dd.IsActive = true;

            }
            DBContext.Doctordetails.Add(dd);
            await DBContext.SaveChangesAsync();

            return (HttpStatusCode.Created);
        }

        [HttpPut("UpdateDoctor")]
        public async Task<HttpStatusCode> UpdateDoctor([FromBody] InsertDoctorDTO updoc)
        {
            var dd = await DBContext.Doctordetails.FirstOrDefaultAsync
              (s => s.DoctorID == updoc.DoctorID);
            {
                dd.DoctorID = updoc.DoctorID;
                dd.RegDate = updoc.RegDate;
                dd.FirstName = updoc.FirstName;
                dd.LastName = updoc.LastName;
                dd.Gender = updoc.Gender;
                dd.Email = updoc.Email;
                dd.BloodGroup = updoc.BloodGroup;
                dd.Mobile1 = updoc.Mobile1;
                dd.Line1 = updoc.Line1;

                await DBContext.SaveChangesAsync();
                return (HttpStatusCode.Created);

            }
        }

        [HttpPut("DeleteDoctor")]
        public async Task<HttpStatusCode> DeleteDoctor(int DoctorID)
        {
            var doc = DBContext.Doctordetails.FirstOrDefault(s => s.DoctorID == DoctorID);
            {
                doc.IsActive = false;

                await DBContext.SaveChangesAsync();

                return (HttpStatusCode.Created);
            }
        }
    }
}
