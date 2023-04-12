using System;
using System.Collections.Generic;

namespace Appointment_DataEntities.Entities;

public partial class Appointment
{
    public Guid AppointmentId { get; set; }

    public Guid? PatientId { get; set; }

    public Guid? DoctorId { get; set; }

    public DateTime Date { get; set; }

    public string? DoctorName { get; set; }

    public string? Concerns { get; set; }

    public string? Status { get; set; }

    public bool? CheckupStatus { get; set; }

    public virtual ICollection<PatientIntialCheckup> PatientIntialCheckups { get; } = new List<PatientIntialCheckup>();
}
