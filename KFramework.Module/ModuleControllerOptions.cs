namespace KFramework.Module
{
    public class ModuleControllerOptions
    {
        public bool UseDependsOnSystem { get; set; } = true;

        public bool DisableChangesAfterInit { get; set; } = true;

        /// <summary>
        /// Don't change this if you are not senior!
        /// </summary>
        public bool DisableChangesOnIniting { get; set; } = true;

        public bool UseReflectionBasedImplementionDetection { get; set; } = false;
    }
}