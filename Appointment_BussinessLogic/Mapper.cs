using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using ad=Appointment_DataEntities.Entities;



namespace BussinessLogic
{
    public static class Mapper
    {
      
        public static Models.Appointment Map(ad.Appointment a)
        {
            return new Models.Appointment()
            {
                AppointmentId=a.AppointmentId,
                PatientId=a.PatientId,
                DoctorId=a.DoctorId,
                Date=a.Date,
                DoctorName=a.DoctorName,
                Concerns=a.Concerns,
                Status=a.Status,
                CheckupStatus=a.CheckupStatus,
                

            };
        }

        public static IEnumerable<Models.Appointment> Map(IEnumerable<ad.Appointment> appointments)
        {
            return appointments.Select(Map).ToList();
        }


        public static ad.Appointment Map(Models.Appointment a)
        {
            return new ad.Appointment()
            {
                AppointmentId = a.AppointmentId,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                Date = a.Date,
                DoctorName = a.DoctorName,
                Concerns = a.Concerns,
                Status = a.Status,
                CheckupStatus=a.CheckupStatus,
                
            };
        }


        //------------------------------------------------PatientMapper-----------------------------------------------------------------------------

        public static Models.PatientIntialCheckUp Map(ad.PatientIntialCheckup p)
        {
            return new Models.PatientIntialCheckUp()
            {
               PicId=p.PicId,
               AppointmentId=p.AppointmentId,
               Height=p.Height,
               Weight=p.Weight,
               Temperature=p.Temperature,
               Spo2=p.Spo2,
               BloodPressure=p.BloodPressure,
               SugarLevel=p.SugarLevel,
               AdditionalDetails=p.AdditionalDetails,


            };
        }

        public static IEnumerable<Models.PatientIntialCheckUp> Map(IEnumerable<ad.PatientIntialCheckup> patientIntials)
        {
            return patientIntials.Select(Map).ToList();
        }
        public static ad.PatientIntialCheckup Map(Models.PatientIntialCheckUp p)
        {
            return new ad.PatientIntialCheckup()
            {
                PicId = p.PicId,
                AppointmentId = p.AppointmentId,
                Height = p.Height,
                Weight = p.Weight,
                Temperature = p.Temperature,
                Spo2 = p.Spo2,
                BloodPressure = p.BloodPressure,
                SugarLevel = p.SugarLevel,
                AdditionalDetails = p.AdditionalDetails

            };
        }

    }
}
