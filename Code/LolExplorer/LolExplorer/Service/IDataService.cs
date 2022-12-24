using LolExplorer.Modele;
namespace LolExplorer.Services
{
    public interface IDataService
    {
        Task Add(ItemApiModel model);

        Task<int> Count();

        Task<List<ItemApi>> List(int currentPage, int pageSize);
        Task<List<ItemApi>> List();

        Task<ItemApi> GetById(int id);

        Task Update(int id, ItemApiModel model);
        Task Delete(int id);
    }
}