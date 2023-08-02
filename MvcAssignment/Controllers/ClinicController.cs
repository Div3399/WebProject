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
    public class ClinicController : ControllerBase
    {
        private readonly DBContext DBContext;

        public ClinicController(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }

        [HttpGet("Clinicdetail")]
        public async Task<ActionResult<List<ClinicdetailDTO>>> Clinicdetail()
        {
            var clinic = await DBContext.Clinicdetails.Select(
                s => new ClinicdetailDTO
                {
                    ClinicID = s.ClinicID,
                    ClinicName = s.ClinicName,
                    AddressLine1 = s.AddressLine1,
                    AddressLine2 = s.AddressLine2,
                    PhoneNo1 = s.PhoneNo1,
                    OpenTime = s.OpenTime,
                    CloseTime = s.CloseTime,
                    EmailID = s.EmailID,
                    DayOfWeek = s.DayOfWeek,
                    IsActive = true

                }
                ).ToListAsync();

            if (clinic.Count < 0)
            {
                return NotFound();

            }
            else
            {
                return clinic;
            }
        }

        [HttpGet("Clinincbyid")]
        public async Task<ActionResult<ClinicdetailDTO>> Clinincbyid(int ClinicID)
        {
            var cl = await DBContext.Clinicdetails.Select(
                s => new ClinicdetailDTO
                {
                    ClinicID = s.ClinicID,
                    ClinicName = s.ClinicName,
                    AddressLine1 = s.AddressLine1,
                    AddressLine2 = s.AddressLine2,
                    PhoneNo1 = s.PhoneNo1,
                    OpenTime = s.OpenTime,
                    CloseTime = s.CloseTime,
                    EmailID = s.EmailID,
                    DayOfWeek = s.DayOfWeek,
                    IsActive = true

                }
                ).FirstOrDefaultAsync(s => s.ClinicID == ClinicID);

            if (cl == null)
            {
                return NotFound();

            }
            else
            {
                return cl;
            }

        }

        [HttpPost ("InsertClinic")]
        public async Task<HttpStatusCode> InsertClinic([FromForm] InsertClinicDTO cldetail)
        {
            var clinic = new Clinicdetail();
            {
                clinic.ClinicID = cldetail.ClinicID;
                clinic.ClinicName = cldetail.ClinicName;
                clinic.AddressLine1 = cldetail.AddressLine1;
                clinic.AddressLine2 = cldetail.AddressLine2;
                clinic.PhoneNo1 = cldetail.PhoneNo1;
                clinic.OpenTime = cldetail.OpenTime;
                clinic.CloseTime = cldetail.CloseTime;
                clinic.EmailID = cldetail.EmailID;
                clinic.DayOfWeek = cldetail.DayOfWeek;
                clinic.IsActive = true;
                

            }
            DBContext.Clinicdetails.Add(clinic);
            await DBContext.SaveChangesAsync();

            return (HttpStatusCode.Created);
        }

        [HttpPut("UpdateClinicdetail")]
        public async Task<HttpStatusCode>UpdateClinicdetail([FromBody] InsertClinicDTO upclinic)
        {
            var clinic = await DBContext.Clinicdetails.FirstOrDefaultAsync
               (s => s.ClinicID== upclinic.ClinicID);
            {
                clinic.ClinicID= upclinic.ClinicID;
                clinic.ClinicName= upclinic.ClinicName;
                clinic.AddressLine1= upclinic.AddressLine1;
                clinic.AddressLine2= upclinic.AddressLine2;
                clinic.PhoneNo1= upclinic.PhoneNo1;
                clinic.OpenTime= upclinic.OpenTime;
                clinic.CloseTime= upclinic.CloseTime;
                clinic.EmailID = upclinic.EmailID;
                clinic.DayOfWeek = upclinic.DayOfWeek;

                await DBContext.SaveChangesAsync();
                return (HttpStatusCode.Created);

            }
        }

        [HttpPut("DeleteClinicdetail")]
        public async Task<HttpStatusCode> DeleteClinicdetail(int ClinicID)
        {
            var clinic = DBContext.Clinicdetails.FirstOrDefault(s => s.ClinicID==ClinicID);
            {
                clinic.IsActive = false;

                await DBContext.SaveChangesAsync();

                return (HttpStatusCode.Created);
            }
        }
    }
}
