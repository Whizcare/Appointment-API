using BussinessLogic;
using Appointment_DataEntities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientCheckUpController : ControllerBase
    {
        private readonly IPatientCheckUP _logic;
        public PatientCheckUpController(IPatientCheckUP logic)
        {
            _logic = logic;

        }
        [HttpGet("GetCheckUpDetailsByAppointmentId")]
        public ActionResult Get([FromHeader] Guid appointment_id)
        {
            try
            {
                var checkUpDetails = _logic.GetCheckUpDetails(appointment_id);
                if (checkUpDetails != null)
                {
                    return Ok(checkUpDetails);
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


        [HttpPost("AddCheckUpDetails")]
        public ActionResult Add([FromBody] Models.PatientIntialCheckUp patientIntialCheckup)
        {
            try
            {


                var r=_logic.AddCheckUpDetails(patientIntialCheckup);
                return Ok(r);
            }
           
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
