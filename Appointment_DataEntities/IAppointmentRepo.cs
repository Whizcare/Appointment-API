using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointment_DataEntities.Entities;

namespace DataEntities
{
    public  interface IAppointmentRepo
    {
        public  List<Appointment_DataEntities.Entities.Appointment> GetAppointmentsByPatient(Guid patient_id);


        public List<Appointment_DataEntities.Entities.Appointment> GetAppointmentsByDate(DateTime date);



        public List<Appointment_DataEntities.Entities.Appointment> GetAppointmentsByDoctor(Guid doctor_id,string status);

        public IEnumerable<Appointment> GetAppointmentsAfterCheckup(DateTime date, Guid doctor_id);



        public Appointment_DataEntities.Entities.Appointment UpdateStatus(Appointment_DataEntities.Entities.Appointment appointment);

        public Appointment UpdateCheckUpStatus(Appointment appointment);


        public Appointment_DataEntities.Entities.Appointment AddAppointment(Appointment_DataEntities.Entities.Appointment appointment);

        public void EmailToPatient(string email, string date, string status);

    }
}
