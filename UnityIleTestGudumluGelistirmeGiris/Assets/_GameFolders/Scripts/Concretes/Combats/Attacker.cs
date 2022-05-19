using UnityTddBeginner.Abstracts.Combats;
using UnityTddBeginner.Abstracts.ScriptableObjects;

namespace UnityTddBeginner.Combats
{
    public class Attacker : IAttacker
    {
        readonly IStats _stats;
        
        public Attacker(IStats stats)
        {
            _stats = stats;
        }

        public int Damage => _stats.CalculateDamage;
    }
}