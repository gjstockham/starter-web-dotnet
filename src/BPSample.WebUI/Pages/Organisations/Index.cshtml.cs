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
        private readonly IMediator mediator;

        public IEnumerable<GetOrganisationList.OrganisationDto> Organisations { get; protected set; }

        public IndexModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task OnGetAsync(CancellationToken cancellationToken)
        {
            Organisations = await mediator.Send(new GetOrganisationList.Query(), cancellationToken);
        }
    }
}
