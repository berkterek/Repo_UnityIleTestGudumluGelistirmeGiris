using NSubstitute;
using UnityEngine;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Inputs;
using UnityTddBeginner.Abstracts.ScriptableObjects;

namespace UnityTddBeginner.EditTests.Helpers
{
    public static class EditModeHelper
    {
        public static IPlayerController GetPlayerController()
        {
            IPlayerController playerController = Substitute.For<IPlayerController>();
            GameObject gameObject = new GameObject();
            playerController.transform.Returns(gameObject.transform);
            playerController.InputReader = Substitute.For<IInputReader>();
            playerController.Stats.Returns(Substitute.For<IPlayerStats>());

            return playerController;
        }
    }
}