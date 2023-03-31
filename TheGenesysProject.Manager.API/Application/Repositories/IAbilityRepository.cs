using System.Threading.Tasks;
using TheGenesysProject.Manager.API.AbilityMaintain.Infrastructure.Repositories.Entities.Entities;

namespace TheGenesysProject.Manager.API.AbilityMaintain.Application.Repositories
{
    internal interface IAbilityRepository
    {
        Task Add(Ability ability);
    }
}