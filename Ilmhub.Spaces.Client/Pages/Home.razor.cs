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
    private bool isAddLeadDialogOpen = false;
    private Lead newLead = new Lead();
    private string selectedStatus = string.Empty;
    private string selectedSource = string.Empty;

    private List<Lead> Leads { get; set; } = new List<Lead>();

    protected override async Task OnInitializedAsync()
    {
        Leads = await LeadDataService.GetAllLeadsAsync();
    }

    private LeadSource GetSelectedSource()
    {
        return string.IsNullOrEmpty(selectedSource) ? LeadSource.Other : Enum.Parse<LeadSource>(selectedSource);
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
            Leads.Add(createdLead);
        }
    }

    private async Task AddNewLead()
    {
        newLead.Status = Enum.Parse<LeadStatus>(selectedStatus);
        newLead.Source = Enum.Parse<LeadSource>(selectedSource);
        var createdLead = await LeadDataService.CreateLeadAsync(newLead);
        Leads.Add(createdLead);
        isAddLeadDialogOpen = false;
    }
}