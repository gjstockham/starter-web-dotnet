namespace BPSample.WebUI.Pages.Organisations
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using BPSample.Application.Features.Organisations.Queries;
    using MediatR;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class IndexModel : PageModel
    {
        private readonly ISender sender;

        public IEnumerable<GetOrganisationList.OrganisationDto> Organisations { get; protected set; }

        public IndexModel(ISender sender)
        {
            this.sender = sender;
        }

        public async Task OnGetAsync(CancellationToken cancellationToken)
        {
            Organisations = await sender.Send(new GetOrganisationList.Query(), cancellationToken);
        }
    }
}
