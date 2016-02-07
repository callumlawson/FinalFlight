using System;
using Assets.Sources.GameLogic.Mood;
using Entitas;
using Random = UnityEngine.Random;

namespace Assets.Sources.Init
{
    public class CreatePilotsSystem : IInitializeSystem, ISetPool
    {
        private Pool systemPool;

        public void SetPool(Pool pool)
        {
            this.systemPool = pool;
        }

        public void Initialize()
        {
            for (int i = 0; i < 7; i++)
            {
                systemPool.CreateEntity()
                    .AddMood(Mood.Depressed)
                    .AddName("Pilot Number: " + i)
                    .AddHealth(Random.value * 100);
            }
        }
    }
}