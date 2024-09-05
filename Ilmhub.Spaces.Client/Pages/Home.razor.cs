using Ilmhub.Spaces.Client.Components;
using Ilmhub.Spaces.Client.Models;
using Ilmhub.Spaces.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using System.Linq;

namespace Ilmhub.Spaces.Client.Pages;

public partial class Home
{
    [Inject] IDialogService? DialogService { get; set; }
    [Inject] ILeadDataService LeadDataService { get; set; } = default!;

    private string SearchTerm { get; set; } = string.Empty;

    private List<Lead> Leads { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        Leads = await LeadDataService.GetAllLeadsAsync();
    }

    private List<Lead> FilteredLeads => Leads
        .Where(lead => string.IsNullOrEmpty(SearchTerm) ||
                       lead!.Name!.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                       lead!.Phone!.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
        .ToList();

    private async Task OpenAddLeadDialogAsync()
    {
        var dialog = await DialogService!.ShowDialogAsync<AddLeadDialog>(new Lead(), new DialogParameters()
        {
            Title = "Add New Lead",
            PreventDismissOnOverlayClick = false,
            PreventScroll = true,
        });

        var result = await dialog.Result;
        if (!result.Cancelled && result.Data != null)
        {
            var newLead = (Lead)result.Data;
            var createdLead = await LeadDataService.CreateLeadAsync(newLead);
            
            // Check if the lead already exists in the list before adding
            if (!Leads.Any(l => l.Id == createdLead.Id))
            {
                Leads.Add(createdLead);
                StateHasChanged(); // Notify the component to re-render
            }
        }
    }
}