using System;
using System.Collections.Generic;
using Entitas;

namespace Assets.Sources.GameLogic.Components
{
    public enum EventState
    {
        Active,
        Removed,
        Presented,
        Dormant
    }

    public struct EventOption
    {
        public string OptionDescription;
        public Action EventResult;
    }
    
    public class GameEventComponent : IComponent
    {
        public string Title;
        public string Description;
        public EventState EventState;
        public List<EventOption> EventOptions;
    }
}
