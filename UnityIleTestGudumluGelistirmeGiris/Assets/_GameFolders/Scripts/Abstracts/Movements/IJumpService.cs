namespace UnityTddBeginner.Abstracts.Movements
{
    public interface IJumpService
    {
        void Tick();
        void FixedTick();
        void ResetCounter();
    }
}