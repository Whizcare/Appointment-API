using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointment_DataEntities.Entities;

namespace DataEntities
{
    public class PatientCheckUpRepo : IPatientCheckUpRepo
    {
        private readonly AppointmentDbContext context;
        public PatientCheckUpRepo(AppointmentDbContext _context)
        {
            context = _context;

        }
        public PatientIntialCheckup AddCheckUpDetails(PatientIntialCheckup intialCheckUp)
        {
            context.PatientIntialCheckups.Add(intialCheckUp);
            context.SaveChanges();
            return intialCheckUp;
        }

        public PatientIntialCheckup GetCheckUpDetails(Guid appointment_id)
        {
            return context.PatientIntialCheckups.Where(a => a.AppointmentId == appointment_id).FirstOrDefault();
        }
    }
}
