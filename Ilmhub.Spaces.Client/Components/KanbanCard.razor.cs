using Ilmhub.Spaces.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Ilmhub.Spaces.Client.Components;

public partial class KanbanCard
{
    [Parameter] public Lead? Lead { get; set; }

    public static Lead? DraggedLead { get; set; }

    private void HandleDragStart(Lead? lead) => DraggedLead = lead;

    private string GetStatusBackgroundColor(LeadStatus status)
    {
        return status switch
        {
            LeadStatus.Created => "#0078D4",  // Blue
            LeadStatus.Contacted => "#8764B8", // Purple
            LeadStatus.NoContact => "#FFC300", // Yellow
            LeadStatus.Acquired => "#107C10", // Green
            LeadStatus.Lost => "#E81123", // Red
            LeadStatus.Closed => "#767676", // Gray
            _ => "#767676"
        };
    }
}