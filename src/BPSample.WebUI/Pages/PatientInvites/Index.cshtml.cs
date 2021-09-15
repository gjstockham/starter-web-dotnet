namespace BPSample.WebUI.Pages.PatientInvites
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading;
    using System.Threading.Tasks;
    using BPSample.Application.Common.Interfaces;
    using BPSample.Application.Features.PatientInvites.Commands;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class IndexModel : PageModel
    {
        private readonly ISender sender;
        private readonly ICurrentOrganisationService currentOrganisationService;

        [BindProperty]
        [Required]
        [Display(Name = "First name")]
        public string GivenName { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Last name")]
        public string FamilyName { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "CHI Number")]
        public string CHI { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Mobile number")]
        public string Sms { get; set; }

        public IndexModel(ISender sender, ICurrentOrganisationService currentOrganisationService)
        {
            this.sender = sender;
            this.currentOrganisationService = currentOrganisationService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var command = new CreatePatientInvite.Command()
            {
                FamilyName = FamilyName,
                GivenName = GivenName,
                CHI = CHI,
                EmailAddress = EmailAddress,
                SmsNumber = Sms,
                OrganisationId = currentOrganisationService.OrganisationId
            };

            await sender.Send(command, cancellationToken);

            //TODO: magic strings
            return RedirectToPage("/Patients/Index");
        }
    }
}
