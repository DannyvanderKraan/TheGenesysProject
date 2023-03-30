using System.Threading.Tasks;
using TheGenesysProject.Manager.API.TraitMaintain.Domain.Entities;

namespace TheGenesysProject.Manager.API.TraitMaintain.Application.Repositories
{
    internal interface ITraitTableRepository
    {
        Task Add(Trait trait);
    }
}