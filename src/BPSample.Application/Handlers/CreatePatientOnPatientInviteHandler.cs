namespace BPSample.Application.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using BPSample.Application.Common.Interfaces.Data;
    using BPSample.Domain.PatientInvites;
    using BPSample.Domain.Patients;
    using MediatR;

    public class CreatePatientOnPatientInviteHandler : INotificationHandler<PatientInviteCreatedEvent>
    {
        private readonly IPatientRepository patientRepository;

        public CreatePatientOnPatientInviteHandler(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public async Task Handle(PatientInviteCreatedEvent notification, CancellationToken cancellationToken)
        {
            var patient = new Patient(
                                notification.PatientInvite.CHI,
                                notification.PatientInvite.GivenName,
                                notification.PatientInvite.FamilyName,
                                notification.PatientInvite.Email,
                                notification.PatientInvite.SmsNumber,
                                notification.PatientInvite.OrganisationId);

            patientRepository.Add(patient);
            await patientRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}
