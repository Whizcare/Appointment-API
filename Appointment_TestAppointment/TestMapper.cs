using System;
using Models;
using EF = Appointment_DataEntities.Entities;
using BussinessLogic;

namespace TestAppointment
{
    [TestFixture]
    public class TestMapper
    {
        [Test]
        public void TestAppointments()
        {
            Models.Appointment a = new Models.Appointment();

            var aa = Mapper.Map(a);

            Assert.That(typeof(EF.Appointment), Is.EqualTo(aa.GetType()));
        }
        [Test]
        public void TestAppointments1()
        {
            EF.Appointment a = new EF.Appointment();
            var appo=Mapper.Map(a);
            Assert.That(typeof(Models.Appointment), Is.EqualTo(appo.GetType()));
        }
        [Test]
        public void TestAppointmentList()
        {
            List<EF.Appointment> app = new List<EF.Appointment>();
            var appm = Mapper.Map(app);
            Assert.That(typeof(List<Models.Appointment>), Is.EqualTo(appm.GetType()));
        }
        [Test]
        public void TestPatient()
        {
            EF.PatientIntialCheckup p=new EF.PatientIntialCheckup();
            var pp=Mapper.Map(p);
            Assert.That(typeof(Models.PatientIntialCheckUp), Is.EqualTo(pp.GetType()));
        }
        [Test]
        public void TestPatient2()
        {
            Models.PatientIntialCheckUp pc=new Models.PatientIntialCheckUp();
            var pp=Mapper.Map(pc);
            Assert.That(typeof(EF.PatientIntialCheckup), Is.EqualTo(pp.GetType())); 
        }

        [Test]
        public void TestPatientCheckupList()
        {
            List<EF.PatientIntialCheckup> pics = new List<EF.PatientIntialCheckup>();
            var pic = Mapper.Map(pics);
            Assert.That(typeof(List<Models.PatientIntialCheckUp>), Is.EqualTo(pic.GetType()));
        }

    }
}