using System.Threading.Tasks;
using TheGenesysProject.Manager.API.AbilityMaintain.Domain.Models;

namespace TheGenesysProject.Manager.API.AbilityMaintain.Application.Repositories
{
    internal interface IAbilityTableRepository
    {
        Task Add(Ability ability);
    }
}