using Avtobus1.DAL.Entities;

namespace Avtobus1.BLL.Services;
public interface IShortUrlService
{
    string GenerateShortUrl();
    Task<string?> GetFullUrlAndIncrementClicksAsync(string shortUrl);
    Task<IEnumerable<Url>> GetListUrl();
    Task<bool> DeleteUrlAsync(string shortUrl);
    Task<bool> AddUrlAsync(string longUrl);
    Task<bool> UpdateUrlAsync(string shortUrl, Url model);
    Task<Url> GetUrlAsync(string shortUrl);
}
