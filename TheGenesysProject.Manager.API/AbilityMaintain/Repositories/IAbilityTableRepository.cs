using System.Threading.Tasks;
using TheGenesysProject.Manager.API.AbilityMaintain.Models;

namespace TheGenesysProject.Manager.API.AbilityMaintain.Repositories
{
    internal interface IAbilityTableRepository
    {
        Task Add(Ability ability);
    }
}