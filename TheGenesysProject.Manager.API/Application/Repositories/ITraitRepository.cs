using System.Threading.Tasks;
using TheGenesysProject.Manager.API.Domain.Trait;

namespace TheGenesysProject.Manager.API.Application.Repositories
{
    internal interface ITraitRepository
    {
        Task Add(Trait trait);
    }
}