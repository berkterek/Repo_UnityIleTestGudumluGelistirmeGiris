using UnityTddBeginner.Abstracts.Combats;
using UnityTddBeginner.Abstracts.ScriptableObjects;

namespace UnityTddBeginner.Abstracts.Controllers
{
    public interface IEnemyController : IEntityController
    {
        IAttacker Attacker { get; set; }
        IEnemyStats Stats { get; }
        IHealth Health { get; }
    }
}