using LolExplorer.Modele;
using LolExplorer.Pages;
using Microsoft.AspNetCore.Components;
using System.Linq;
//namespace de la page
namespace LolExplorer.Components;

public partial class CraftingItem
{
    [Parameter]
    public int Index { get; set; }

    [Parameter]
    public ItemApi Item { get; set; }

    [Parameter]
    public bool NoDrop { get; set; }

    [CascadingParameter]
    public Crafting Parent { get; set; }

    internal void OnDragEnter()
    {
        if (NoDrop)
        {
            return;
        }

        Parent.Actions.Add(new CraftingAction { Action = "Drag Enter", Item = this.Item, Index = this.Index });
    }

    internal  void OnDragLeave()
    {
        if (NoDrop)
        {
            return;
        }
        
        Parent.Actions.Add(new CraftingAction { Action = "Drag Leave", Item = this.Item, Index = this.Index });
    }
    internal void OnDragEnd()
    {
        if (NoDrop)
        {
            return;
        }

        Parent.RecipeItems[this.Index] = null;
        Item = null;
        Parent.CheckRecipe();
    }

    internal void OnDrop()
    {
        if (NoDrop)
        {
            return;
        }

        if(Parent is InventoryItem) /// so inventory dont have the same item multipls time its a personnel choice
        {
            if (Parent.CurrentDragItem != null)
            {
                if (!Parent.RecipeItems.Any(i => i !=null && i.Id == Parent.CurrentDragItem.Id) )
                {
                    this.Item = Parent.CurrentDragItem;
                    Parent.RecipeItems[this.Index] = this.Item;
                }
                else
                {
                    if (Parent.RecipeItems.Contains(Parent.CurrentDragItem))
                    {

                        this.Item = Parent.CurrentDragItem;
                        Parent.RecipeItems[Parent.RecipeItems.IndexOf(this.Item)] =null  ;
                        Parent.RecipeItems[this.Index] = this.Item;
                    }
                }
            }
        }
        else
        {
            this.Item = Parent.CurrentDragItem;
            Parent.RecipeItems[this.Index] = this.Item;
        }
       

        Parent.Actions.Add(new CraftingAction { Action = "Drop", Item = this.Item, Index = this.Index });

        // Check recipe
        Parent.CheckRecipe();
    }

    private void OnDragStart()
    {
        Parent.CurrentDragItem = this.Item;

        Parent.Actions.Add(new CraftingAction { Action = "Drag Start", Item = this.Item, Index = this.Index });
    }
}