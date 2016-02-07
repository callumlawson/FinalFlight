using System;
using System.Collections.Generic;
using Entitas;

namespace Assets.Sources.GameLogic.Components
{
    public struct EventOption
    {
        public string OptionDescription;
        public Action EventResult;
    }
    
    public class GameEventComponent : IComponent
    {
        public string Title;
        public string Description;
        public Func<bool> Predicate;
        public List<EventOption> EventOptions;
    }
}
