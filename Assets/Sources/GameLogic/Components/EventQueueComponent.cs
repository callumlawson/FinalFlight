﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.GameLogic.Meta;
using Entitas;

namespace Assets.Sources.GameLogic.Components
{
    public class EventQueueComponent : IComponent
    {
        public Queue<GameEventComponent> PendingEventQueue;
    }
}
