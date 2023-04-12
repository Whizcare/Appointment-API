using Appointment_DataEntities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace DataEntities
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly AppointmentDbContext context;
        public AppointmentRepo(AppointmentDbContext _context)
        {
            context = _context;
        }
        public Appointment AddAppointment(Appointment appointment)
        {
            context.Appointments.Add(appointment);
            context.SaveChanges();
            return appointment;
        }

        public void EmailToPatient(string email, string date, string status)
        {
            MailMessage mailMessage = new MailMessage();
            string toEmail = email;
            string d = date;
            string s = "", b = "";
            string stat = status;
            switch (stat)
            {
                case "Accepted":
                    s = "Appointment Accepted";
                    b = $"Dear applicant, \n\nYour Appointment has been accepted from the Doctor on {d}.\nThank you.\nWhizcare Hospital\nIndia";
                    break;
                case "Rejected":
                    s = "Appointment Rejected";
                    b = $"Dear applicant, \n\nYour Appointment has been rejected from the Doctor on {d}. Sorry for the inconvinience.\nPlease Re-Schedule your Appointment.\n\nThank you.\nWhizcare Hospital\nIndia";
                    break;
                case "Sent":
                    s = "Appointment Booked Successfully";
                    b = $"Dear applicant, \n\nYour Appointment has been booked for the doctor on {d}.\nThank you.\nWhizcare Hospital\nIndia";
                    break;
                default:
                    break;
            }
            string fromEmail = "whizcarehospitalgroup@gmail.com";
            string pass = "lovypueypvddymur";
            string smtpHost = "smtp.gmail.com";
            int smtpPort = 587;

            // Create a MailMessage object
            mailMessage = new MailMessage(fromEmail, toEmail);
            mailMessage.Subject = s;
            mailMessage.Body = b;
            // Create a SmtpClient object
            SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(fromEmail, pass);
            smtpClient.UseDefaultCredentials = false;

            // Send the email
            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("Email sent successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }

        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            var find = context.Appointments.Where(a => a.Date == date.Date && a.Status == "Accepted" && a.CheckupStatus==false).ToList();
            return find;
        }

        public List<Appointment> GetAppointmentsByDoctor(Guid doctor_id, string status)
        {
            return context.Appointments.Where(a => a.DoctorId == doctor_id && a.Status == status ).ToList();
        }

        public IEnumerable<Appointment> GetAppointmentsAfterCheckup(DateTime date, Guid doctor_id)
        {
            var apps=(from a in context.Appointments
                      join c in context.PatientIntialCheckups
                      on a.AppointmentId equals c.AppointmentId
                      where a.DoctorId==doctor_id
                      && a.Date==date.Date
                      && a.CheckupStatus==true
                      && a.Status=="Accepted"
                      select a).ToList();
            return apps;
        }

        public List<Appointment> GetAppointmentsByPatient(Guid patient_id)
        {
            var app=(from a in context.Appointments
                     where a.PatientId==patient_id
                     orderby a.Date descending
                     select a).ToList();
            return app;
        }


        public Appointment UpdateStatus(Appointment appointment)
        {
            context.Appointments.Update(appointment);
            context.SaveChanges();
            return appointment;
        }
        public Appointment UpdateCheckUpStatus(Appointment appointment)
        {
            context.Appointments.Update(appointment);
            context.SaveChanges();
            return appointment;
        }

    }
       
}