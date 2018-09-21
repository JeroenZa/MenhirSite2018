using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MenhirSite.Model;
using MenhirSite.Repository.Interfaces;
using MenhirSite.Services.Interface;

namespace MenhirSite.Services
{
    public class TeamService : GenericService<Team>, ITeamService
    {
        private readonly ITeamRepository _repository;

        public TeamService(IUnitOfWork unitOfWork, ITeamRepository repository) : base(unitOfWork, repository)
        {
            _repository = repository;
        }


        public async Task<Team> GetTeamByTeamNameAsync(string name)
        {
            return await FindByPredicate(t => t.Name == name);
        }

        public async Task<Team> GetTeamByINbbIdAsync(string id)
        {
            return await FindByPredicate(t => t.NbbId == id);
        }

        public async Task<Team> GetTeamByISportLinkIdAsync(string id)
        {
            return await FindByPredicate(t => t.NbbId == id);
        }

        public async Task<IEnumerable<string>> GetTeamMenuNamesAsync()
        {
            var all = await _repository.GetAllAsync();
            return all.Select(x => x.MenuName);
        }

        public async Task<IEnumerable<Team>> GetActiveTeamsAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}