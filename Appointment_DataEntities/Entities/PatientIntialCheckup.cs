using System;
using System.Collections.Generic;

namespace Appointment_DataEntities.Entities;

public partial class PatientIntialCheckup
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

    public virtual Appointment? Appointment { get; set; }
}
