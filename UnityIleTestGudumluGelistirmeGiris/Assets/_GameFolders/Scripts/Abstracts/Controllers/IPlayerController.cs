using UnityTddBeginner.Abstracts.Inputs;

namespace UnityTddBeginner.Abstracts.Controllers
{
    public interface IPlayerController : IEntityController
    {
        IInputReader InputReader { get; set; }
    }
}