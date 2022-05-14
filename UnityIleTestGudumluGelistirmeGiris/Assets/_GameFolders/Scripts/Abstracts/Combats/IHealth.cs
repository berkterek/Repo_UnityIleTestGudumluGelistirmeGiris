
namespace UnityTddBeginner.Abstracts.Combats
{
    public interface IHealth
    {
        int CurrentHealth { get; }
        void TakeDamage(IAttacker attacker);
        event System.Action OnTookDamage;
        event System.Action OnDead;
    }
}