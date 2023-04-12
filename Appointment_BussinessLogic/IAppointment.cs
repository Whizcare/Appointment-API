using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public interface IAppointment
    {
        public  IEnumerable<Models.Appointment> GetAppointmentsByPatient(Guid patient_id);

        public IEnumerable<Models.Appointment> GetAppointmentsByDate(DateTime date);

        public IEnumerable<Models.Appointment> GetAppointmentsByDoctor_idByStatus(Guid doctor_id,string status);

        public IEnumerable<Models.Appointment> GetAppointmentsAfterCheckup(DateTime date,Guid doctor_id);

        public Models.Appointment UpdateStatus(Guid appointment_id,string status);
        public Models.Appointment UpdateCheckUpStatus(Guid appointment_id, bool status);


        public Models.Appointment AddAppointment(Models.Appointment appointment);

        public void EmailFunc(string email, string date, string status);

    }
}
