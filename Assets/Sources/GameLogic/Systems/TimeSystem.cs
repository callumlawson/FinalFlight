using Entitas;
using UnityEngine;

namespace Assets.Sources.GameLogic.Systems
{
    class TimeSystem : IExecuteSystem, IInitializeSystem
    {
        private const int SecondsPerDay = 5;

        private float timeOfLastUpdate;
        private int dayOfLastUpdate;

        public void Initialize()
        {
            timeOfLastUpdate = GetSeconds();
        }

        public void Execute()
        {
            if (Pools.pool.isPaused)
            {
                timeOfLastUpdate = GetSeconds();
            }
            else
            {
                var currentTime = GetSeconds();
                var elapsedTimeInSeconds = currentTime - timeOfLastUpdate;
                var elapsedDays = elapsedTimeInSeconds/SecondsPerDay;
                Pools.pool.ReplaceTime(Pools.pool.time.Time + elapsedDays);
                timeOfLastUpdate = currentTime;
            }

            var day = Mathf.CeilToInt(Pools.pool.time.Time);
            if (day != dayOfLastUpdate)
            {
                Pools.pool.ReplaceDay(day);
                dayOfLastUpdate = day;
            }
        }

        private static float GetSeconds()
        {
            return Time.time;
        }
    }
}
