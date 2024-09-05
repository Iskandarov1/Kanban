using Ilmhub.Spaces.Client.Models;
using Microsoft.AspNetCore.Components;

namespace Ilmhub.Spaces.Client.Components;

public partial class KanbanCard
{
    [Parameter] public Lead? Lead { get; set; }

    public static Lead? DraggedLead { get; set; }

    private void HandleDragStart(Lead? lead) => DraggedLead = lead;

    private string GetStatusClass(LeadStatus status)
    {
        return status.ToString().ToLower();
    }
}