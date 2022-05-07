using UnityEngine;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Inputs;

namespace UnityTddBeginner.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        //Movement
        
        //Flip
        //Jump or Double Jump
        //Attack
        //Health
        //Collect
        //Animation
        public IInputReader InputReader { get; set; }
    }    
}