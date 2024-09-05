using Ilmhub.Spaces.Client.Models;
using Ilmhub.Spaces.Client.Services;
using Microsoft.AspNetCore.Components;

namespace Ilmhub.Spaces.Client.Components;

public partial class KanbanBoard
{
    [Inject] ILeadDataService? LeadDataService { get; set; }
    [Parameter] public List<Lead> Leads { get; set; } = [];

    private List<Lead> LeadsInColumn(List<LeadStatus> statuses) =>
        Leads.Where(l => statuses.Contains(l.Status))
             .OrderByDescending(l => l.ModifiedAt)
             .ToList();

    private async Task OnDrop(Lead lead, LeadStatus newStatus)
    {
        if (lead.Status != newStatus)
        {
            lead.Status = newStatus;
            lead.ModifiedAt = DateTime.Now;
            await UpdateLeadAsync(lead);
            StateHasChanged();
        }
    }

    private async Task UpdateLeadAsync(Lead lead)
    {
        var updatedLead = await LeadDataService!.UpdateLeadOrDefaultAsync(lead);
        var index = Leads.FindIndex(l => l.Id == updatedLead!.Id);
        if (index != -1)
        {
            Leads[index] = updatedLead!;
        }
    }
}