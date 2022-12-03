using LolExplorer.Modele;

public interface IDataService
{
    Task Add(ItemApiModel model);

    Task<int> Count();

    Task<List<ItemApi>> List(int currentPage, int pageSize);

    Task<ItemApi> GetById(int id);

    Task Update(int id, ItemApiModel model);
}