using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Sources.GameLogic.Components
{
    public enum EventState
    {
        Dormant,
        Pending,
        Presented
    }

    public class GameEventStateComponent : IComponent
    {
        public EventState EventState;
    }
}
