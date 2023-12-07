namespace Task_3.Scripts.Loader
{
    public interface ISceneLoaderMediator
    {
        void GoToMainMenu();
        void GoToGameplay(LeveLoadingData data);
    }
}