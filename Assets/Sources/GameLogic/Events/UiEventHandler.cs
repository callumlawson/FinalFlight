using System;
using UnityEngine;

namespace Assets.Sources.GameLogic.Events
{
    public class UiEventHandler : UnityEngine.MonoBehaviour
    {
        public static Action<string> NavigationEventReceived;

        //TODO: Strings are icky
        public void FireNavigationEvent(string navEvent)
        {
            if (NavigationEventReceived != null)
            {
                NavigationEventReceived(navEvent);
            }
        }
    }
}
