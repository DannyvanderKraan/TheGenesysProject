using System.Threading.Tasks;
using TheGenesysProject.Manager.API.TraitMaintain.Domain.Entities;

namespace TheGenesysProject.Manager.API.TraitMaintain.Application.Repositories
{
    internal interface ITraitRepository
    {
        Task Add(Trait trait);
    }
}