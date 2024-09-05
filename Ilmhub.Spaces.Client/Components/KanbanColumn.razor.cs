using Ilmhub.Spaces.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Ilmhub.Spaces.Client.Components;

public partial class KanbanColumn
{
    [Parameter] public string? Title { get; set; }
    [Parameter] public List<Lead> Leads { get; set; } = [];
    [Parameter] public EventCallback<Lead> OnDrop { get; set; }

    private async Task HandleDrop(DragEventArgs e)
    {
        if (KanbanCard.DraggedLead != null)
        {
            KanbanCard.DraggedLead.ModifiedAt = DateTime.Now;
            await OnDrop.InvokeAsync(KanbanCard.DraggedLead);
            KanbanCard.DraggedLead = null;
        }
        StateHasChanged();
    }
}