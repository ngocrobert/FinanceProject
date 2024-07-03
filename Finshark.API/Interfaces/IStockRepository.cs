using Finshark.API.Dtos.Stock;
using Finshark.API.Helpers;
using Finshark.API.Models;

namespace Finshark.API.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);
        Task<Stock?> GetByIdAsync(int id); //FirstOrDefault can be Null
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto  stockDto);
        Task<Stock?> DeleteAsync(int id);

        Task<bool> StockExists(int id);

        Task<Stock?> GetBySymbolAsync(string symbol);
    }
}
