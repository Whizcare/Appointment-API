using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public interface IPatientCheckUP
    {
        public Models.PatientIntialCheckUp GetCheckUpDetails(Guid appointment_id);

        public Models.PatientIntialCheckUp AddCheckUpDetails(Models.PatientIntialCheckUp initialCheckUp);

    
    }
}
