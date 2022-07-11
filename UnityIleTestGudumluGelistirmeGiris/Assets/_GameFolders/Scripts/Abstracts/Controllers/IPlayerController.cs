using UnityTddBeginner.Abstracts.Combats;
using UnityTddBeginner.Abstracts.Inputs;
using UnityTddBeginner.Abstracts.Movements;
using UnityTddBeginner.Abstracts.ScriptableObjects;

namespace UnityTddBeginner.Abstracts.Controllers
{
    public interface IPlayerController : IEntityController
    {
        IInputReader InputReader { get; set; }
        IPlayerStats Stats { get; }
        IHealth Health { get; }
        IAttacker Attacker { get; }
        IJumpService JumpManager { get; }
    }
}