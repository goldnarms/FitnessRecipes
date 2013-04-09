using Glimpse.Core.Extensibility;
using Glimpse.Core.Message;

namespace FitnessRecipes.Helpers
{
    public class TimelineTracer : IInspector
    {
        public void Setup(IInspectorContext context)
        {
            context.MessageBroker.Subscribe<ITimelineMessage>(TraceMessage);
        }

        private void TraceMessage(ITimelineMessage message)
        {
            var output = string.Format(
                "{0} - {1} ms from beginning of request. Took {2} ms to execute.",
                message.EventName,
                message.Offset.Milliseconds,
                message.Duration.Milliseconds);

            //System.Diagnostics.Trace.TraceInformation(output, message.EventCategory.Name);
        }
    }
}