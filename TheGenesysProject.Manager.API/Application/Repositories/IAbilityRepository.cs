using System.Threading.Tasks;
using TheGenesysProject.Manager.API.Domain.Entities;

namespace TheGenesysProject.Manager.API.Application.Repositories
{
    internal interface IAbilityRepository
    {
        Task Add(Ability ability);
    }
}