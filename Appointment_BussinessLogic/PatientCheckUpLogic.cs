using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointment_DataEntities.Entities;
using DataEntities;
using Models;

namespace BussinessLogic

{
    public class PatientCheckUpLogic : IPatientCheckUP
    {
      
        private readonly IPatientCheckUpRepo repo;
        public PatientCheckUpLogic(IPatientCheckUpRepo _repo)
        {
            repo = _repo;
           

        }

        public PatientIntialCheckUp AddCheckUpDetails(PatientIntialCheckUp initialCheckUp)
        {
            return Mapper.Map(repo.AddCheckUpDetails(Mapper.Map(initialCheckUp)));
        }

        public PatientIntialCheckUp GetCheckUpDetails(Guid appointment_id)
        {
            return Mapper.Map(repo.GetCheckUpDetails(appointment_id));
        }


    }
}
