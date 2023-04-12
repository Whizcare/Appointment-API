using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointment_DataEntities.Entities;

namespace DataEntities
{
    public interface IPatientCheckUpRepo
    {
        public Appointment_DataEntities.Entities.PatientIntialCheckup GetCheckUpDetails(Guid appointment_id);
        public Appointment_DataEntities.Entities.PatientIntialCheckup AddCheckUpDetails(PatientIntialCheckup intialCheckUp);
    }
}
