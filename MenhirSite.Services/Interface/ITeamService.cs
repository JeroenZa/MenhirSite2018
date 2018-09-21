using MenhirSite.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenhirSite.Services.Interface
{
    public interface ITeamService : IGenericService<Team>
    {
        Task<Team> GetTeamByTeamNameAsync(string name);
        Task<Team> GetTeamByINbbIdAsync(string id);
        Task<Team> GetTeamByISportLinkIdAsync(string id);
        Task<IEnumerable<string>> GetTeamMenuNamesAsync();
        Task<IEnumerable<Team>> GetActiveTeamsAsync();
    }
}