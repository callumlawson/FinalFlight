using System;
using Assets.Sources.GameLogic.Components;

namespace Assets.Sources.GameLogic.Events
{
    public static class UiEventHandler
    {
        public static Action<string> NavigationEventReceived;
        public static Action<EventOption> OptionSelectedEventReceived;

        //TODO: Magic strings are icky
        public static void FireNavigationEvent(string navEvent)
        {
            if (NavigationEventReceived != null)
            {
                NavigationEventReceived(navEvent);
            }
        }

        public static void FireOptionSelectedEvent(EventOption eventOption)
        {
            if (OptionSelectedEventReceived != null)
            {
                OptionSelectedEventReceived(eventOption);
            }
        }
    }
}
