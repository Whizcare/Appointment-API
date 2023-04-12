using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PatientIntialCheckUp
    {
        public Guid PicId { get; set; }

        public Guid? AppointmentId { get; set; }

        public int? Height { get; set; }

        public double? Weight { get; set; }

        public double? Temperature { get; set; }

        public double? Spo2 { get; set; }

        public string? BloodPressure { get; set; }

        public int? SugarLevel { get; set; }

        public string? AdditionalDetails { get; set; }


    }

}

