namespace Task3.Scripts
{
    public interface ITrader
    {
        bool CanInteract(ISocialize player);
        void Interact(ISocialize player);
    }
}