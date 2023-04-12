using AutoFixture;
using BussinessLogic;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Models;
using Appointment_DataEntities.Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Controllers;

namespace Appointment_TestAppointment
{
    public class TestControllerPatient
    {
        private readonly IFixture _fixture;
        private readonly Mock<IPatientCheckUP> _patientCheckupLogic;
        private readonly PatientCheckUpController _patientCheckUpController;

        public TestControllerPatient()
        {
            _fixture = new Fixture();
            _patientCheckupLogic = _fixture.Freeze<Mock<IPatientCheckUP>>();
            _patientCheckUpController = new PatientCheckUpController(_patientCheckupLogic.Object);
        }

        [Fact]
        public void GetCheckupDetails_OkResponse_Test()
        {
            var checkup = _fixture.Create<PatientIntialCheckUp>();
            var appointment_id = _fixture.Create<Guid>();

            _patientCheckupLogic.Setup(x => x.GetCheckUpDetails(appointment_id)).Returns((PatientIntialCheckUp)checkup);

            var result = _patientCheckUpController.Get(appointment_id);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(checkup.GetType());
            _patientCheckupLogic.Verify(x => x.GetCheckUpDetails(appointment_id), Times.AtLeastOnce());

        }
        [Fact]
        public void GetCheckupDetails_BadRequest_Test()
        {
            List<PatientIntialCheckUp> patientIntialCheckUps = null;
            var app_id = _fixture.Create<Guid>();
            _patientCheckupLogic.Setup(x => x.GetCheckUpDetails(app_id)).Throws(new Exception("Something Went Wrong"));

            var result = _patientCheckUpController.Get(app_id);
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _patientCheckupLogic.Verify(x => x.GetCheckUpDetails(app_id), Times.AtLeastOnce());
        }
        [Fact]
        public void GetCheckupDetails_NoContent_Test()
        {
            List<PatientIntialCheckup> patientIntialCheckups = null;
            var app_id = _fixture.Create<Guid>();
            _patientCheckupLogic.Setup(x => x.GetCheckUpDetails(app_id));
            var result = _patientCheckUpController.Get(app_id);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NoContentResult>();
            _patientCheckupLogic.Verify(x => x.GetCheckUpDetails(app_id), Times.AtLeastOnce());

        }

        [Fact]
        public void AddCheckupDetails_OKResponse_Test()
        {

            var acheck = _fixture.Create<Models.PatientIntialCheckUp>();
            _patientCheckupLogic.Setup(x => x.AddCheckUpDetails(acheck)).Returns(acheck);

            var result = _patientCheckUpController.Add(acheck);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();

            _patientCheckupLogic.Verify(x => x.AddCheckUpDetails(acheck), Times.AtLeastOnce());
        }
        [Fact]
        public void AddChechkupDetails_BadRequest_Test()
        {
            var acheckup = _fixture.Create<PatientIntialCheckUp>();
            _patientCheckupLogic.Setup(x => x.AddCheckUpDetails(acheckup)).Throws(new Exception("Something went wrong"));
            var result = _patientCheckUpController.Add(acheckup);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _patientCheckupLogic.Verify(x => x.AddCheckUpDetails(acheckup), Times.AtLeastOnce());
        }






    }

}
