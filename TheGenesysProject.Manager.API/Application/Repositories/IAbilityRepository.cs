using System.Threading.Tasks;
using TheGenesysProject.Manager.API.Domain.Ability;

namespace TheGenesysProject.Manager.API.Application.Repositories
{
    internal interface IAbilityRepository
    {
        Task Add(Ability ability);
    }
}