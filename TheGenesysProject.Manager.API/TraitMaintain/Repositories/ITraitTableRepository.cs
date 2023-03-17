using System.Threading.Tasks;
using TheGenesysProject.Manager.API.TraitMaintain.Models;

namespace TheGenesysProject.Manager.API.TraitMaintain.Repositories
{
    internal interface ITraitTableRepository
    {
        Task Add(Trait trait);
    }
}