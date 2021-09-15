namespace BPSample.WebUI.Authentication.Services
{
    using System;
    using BPSample.Application.Common.Interfaces;

    public class CurrentOrganisationService : ICurrentOrganisationService
    {
        //TODO: Real values...
        public Guid OrganisationId { get { return Guid.NewGuid(); } }
    }
}
