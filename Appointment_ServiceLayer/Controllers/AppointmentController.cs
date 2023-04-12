using BussinessLogic;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private  readonly IAppointment _logic;
        
        public AppointmentController(IAppointment logic)
        {
            _logic = logic;
            
        }

        [HttpGet("getappointmentsbypatientid")]
        public ActionResult GetAppointmentByPatientId([FromHeader] Guid id)
        {
            try
            {

                var appointments = _logic.GetAppointmentsByPatient(id);
                if (appointments != null)
                {
                    return Ok(appointments);
                }
                else
                {
                    return NoContent();
                }
            }
            
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("getappointmentsbyDoctoridAndStatus")]
        public ActionResult GetAppointmentsByDoctorId([FromHeader] Guid id ,[FromHeader] string status)
        {
            try
            {

                var appointments = _logic.GetAppointmentsByDoctor_idByStatus(id,status);
                if (appointments != null)
                {
                    return Ok(appointments);
                }
                else
                {
                    return NoContent();
                }
            }
            
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAppointmentsAfterCheckup")]
        public ActionResult GetAppointmentsAfterCheckup([FromHeader] Guid doc_id , [FromHeader] string dates )
        {
            try
            {
                var date1 = DateTime.Parse(dates);
                var appointment = _logic.GetAppointmentsAfterCheckup(date1,doc_id);
                if (appointment != null)
                {
                    return Ok(appointment);
                }
                else
                {
                    return NoContent();
                }
            }
             
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("BookAppiontment")] // Trying to create a resource on the server
        public ActionResult AddAppointment([FromBody] Models.Appointment a)
        {
            try
            {
                a.Date = a.Date.AddDays(1);

                var result=_logic.AddAppointment(a);
                return Ok(result);
            }
           
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpGet("getappointmentsbyDate")]
        public ActionResult GetAppointmentByDate([FromHeader] string date1)
        {
            try
            {
                var date = DateTime.Parse(date1);
                var appointment = _logic.GetAppointmentsByDate(date);
                if (appointment != null)
                {
                    return Ok(appointment);
                }
                else
                {
                    return NoContent();
                }
            }
           
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       



        [HttpPut("Update")]
        public  IActionResult UpdateStatus( Guid AppointmentId , string status1)
        {
            try
            {

               var result= _logic.UpdateStatus(AppointmentId, status1);
                return Ok(result);
            }
            
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateCheckUp")]
        public IActionResult UpdateCheckUpStatus(Guid AppointmentId, bool status1)
        {
            try
            {

                var result = _logic.UpdateCheckUpStatus(AppointmentId, status1);
                return Ok(result);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Email_Notification")]

        public IActionResult SendEmail([FromHeader]string Email, [FromHeader]string date1, [FromHeader]string status)
        {
            try
            {
                _logic.EmailFunc(Email, date1, status);
                return Ok("Email Sent");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
