using LolExplorer.Modele;
using LolExplorer.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace LolExplorer.Components
{
    public partial class Crafting
    {

        public Crafting()
        {
            Actions = new ObservableCollection<CraftingAction>();
            Actions.CollectionChanged += OnActionsCollectionChanged;
            this.RecipeItems = new List<ItemApi> { null, null, null };
        }

        [Inject]
        public IStringLocalizer<Crafting> Localizer { get; set; }

        public ObservableCollection<CraftingAction> Actions { get; set; }
        public ItemApi CurrentDragItem { get; set; }

        [Parameter]
        public List<ItemApi> Items { get; set; }

        public List<ItemApi> RecipeItems { get; set; }

        public List<ItemApi> RecipeResult { get; set; }=new();

        [Parameter]
        public List<CraftingRecipe> Recipes { get; set; }

        /// <summary>
        /// Gets or sets the java script runtime.
        /// </summary>
        [Inject]
        internal IJSRuntime JavaScriptRuntime { get; set; }

       
        public virtual  void CheckRecipe()
        {
            RecipeResult.Clear();
            List<String> currentModel = new();
            // Get the current model
            foreach (ItemApi item in RecipeItems)
            {
                if(item!=null)
                 currentModel.Add(item.Id.ToString());
            }

            this.Actions.Add(new CraftingAction { Action = $"Items : {currentModel}" });
            bool foundItem = false;
            foreach (var craftingRecipe in Recipes)
            {
                bool correctRecepie=true;
                // Get the recipe model
                List<String> recipeModel = new List<String>(craftingRecipe.Have);
                foreach(String id in currentModel) {
                    if (recipeModel.Contains(id))
                    {
                        recipeModel.Remove(id);
                    }
                    else
                    {
                        correctRecepie=false;
                    }
                }
                this.Actions.Add(new CraftingAction { Action = $"Recipe model : {recipeModel}" });


                if ( recipeModel.Count() == 0 && correctRecepie)
                {
                    
                    foundItem = true;
                    RecipeResult.Add(craftingRecipe.Give);
                }
            }
            if (!foundItem )
                RecipeResult.Clear();
            StateHasChanged();
        }

        private void OnActionsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            JavaScriptRuntime.InvokeVoidAsync("Crafting.AddActions", e.NewItems);
  
        }

        //ces fonction exister pour supprimer contenu de la craft table sauf que avec l'arriver de la demande de inventory y a plus besoin
       /* protected virtual void ClearCrafting0()
        {
            RecipeItems[0] = null;
            craftingItem0.Item = null;
            CheckRecipe();
        }
        protected virtual void ClearCrafting1()
        {
            RecipeItems[1] = null;
            craftingItem1.Item = null;
            CheckRecipe();
        }
        protected virtual void ClearCrafting2()
        {

            RecipeItems[2] = null;
            craftingItem2.Item = null;
            CheckRecipe(); 
         
        }
*/
       

        

    }

}
