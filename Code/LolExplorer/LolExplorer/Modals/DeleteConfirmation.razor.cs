using Blazored.Modal.Services;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using LolExplorer.Modele;
using LolExplorer.Services;
using LolExplorer.Pages;
using Microsoft.Extensions.Localization;

namespace LolExplorer.Modals
{
    public partial class DeleteConfirmation
    {
        [Inject]
        public IStringLocalizer<DeleteConfirmation> Localizer { get; set; }

        [CascadingParameter]
        public BlazoredModalInstance ModalInstance { get; set; }

        [Inject]
        public IDataService DataService { get; set; }

        [Parameter]
        public int Id { get; set; }

        private ItemApi item = new ItemApi();

        protected override async Task OnInitializedAsync()
        {
            // Get the item
            item = await DataService.GetById(Id);
        }

        void ConfirmDelete()
        {
            ModalInstance.CloseAsync(ModalResult.Ok(true));
        }

        void Cancel()
        {
            ModalInstance.CancelAsync();
        }
    }
}
