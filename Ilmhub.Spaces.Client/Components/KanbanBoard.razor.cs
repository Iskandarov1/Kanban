using Ilmhub.Spaces.Client.Models;
using Microsoft.AspNetCore.Components;

namespace Ilmhub.Spaces.Client.Components;

public partial class KanbanBoard
{
    [Parameter] public List<Lead> Leads { get; set; } = [];

    private List<Lead> LeadsInColumn(List<LeadStatus> statuses) =>
        Leads.Where(l => statuses.Contains(l.Status)).ToList();

    private void OnDrop(Lead lead, LeadStatus newStatus)
    {
        lead.Status = newStatus;
        StateHasChanged();
    }
}