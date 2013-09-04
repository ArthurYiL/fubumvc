using FubuCore;
using FubuCore.Logging;
using StructureMap.AutoMocking;

namespace FubuMVC.Tests
{
    // TODO -- get this into FubuTestingExtensions
    public static class InteractionContextExtensions
    {
        public static RecordingLogger RecordLogging<T>(this RhinoAutoMocker<T> mocker) where T : class
        {
            var logger = new RecordingLogger();
            mocker.Inject<ILogger>(logger);

            return logger;
        }

        public static RecordingLogger RecordedLog<T>(this RhinoAutoMocker<T> mocker) where T : class
        {
            return mocker.Get<ILogger>().As<RecordingLogger>();
        }
    }
}