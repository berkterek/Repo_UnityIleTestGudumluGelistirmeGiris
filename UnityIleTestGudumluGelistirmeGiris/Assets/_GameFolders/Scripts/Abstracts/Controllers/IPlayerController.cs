using UnityTddBeginner.Abstracts.Inputs;
using UnityTddBeginner.Abstracts.ScriptableObjects;

namespace UnityTddBeginner.Abstracts.Controllers
{
    public interface IPlayerController : IEntityController
    {
        IInputReader InputReader { get; set; }
        IPlayerStats Stats { get; }
    }
}