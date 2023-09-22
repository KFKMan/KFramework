namespace KFramework
{
    public class DefaultLifeManager : IApplicationLifeManager
    {
#warning DefaultLifeManager is not implemented !
        public EventHandler OnClosing { get; set; }
        public EventHandler OnClosed { get; set; }
        public EventHandler OnStarting { get; set; }
        public EventHandler OnStarted { get; set; }
        public EventHandler OnError { get; set; }

        public void Close()
        {
            
        }

        public Task CloseAsync()
        {
            return Task.CompletedTask;
        }
    }
}