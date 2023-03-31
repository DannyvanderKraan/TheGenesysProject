using System.Threading.Tasks;
using TheGenesysProject.Manager.API.Domain.Entities;

namespace TheGenesysProject.Manager.API.Application.Repositories
{
    internal interface ITraitRepository
    {
        Task Add(Trait trait);
    }
}