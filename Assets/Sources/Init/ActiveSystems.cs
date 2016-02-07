using Assets.Sources.GameLogic.Systems;
using Entitas;
using Entitas.Unity.VisualDebugging;

namespace Assets.Sources.Init
{
    public static class ActiveSystems
    {
        public static Systems GetSystems(Pool pool)
        {
#if (UNITY_EDITOR)
            return new DebugSystems()
#else
                return new Systems()
#endif
                // Initialize
                .Add(pool.CreateSystem<RemoveViewSystem>())
                .Add(pool.CreateSystem<AddViewSystem>())
                .Add(pool.CreateSystem<CreatePilotsSystem>())
                .Add(pool.CreateSystem<StartGameSystem>())
                .Add(pool.CreateSystem<CreateEventsSystem>())
                .Add(pool.CreateSystem<CreateAircraftSystem>())
                .Add(pool.CreateSystem<KeybindingSystem>())
                .Add(pool.CreateSystem<TimeSystem>())
                .Add(pool.CreateSystem<UINavigationSystem>())
                .Add(pool.CreateSystem<EventPredicateCheckingSystem>())
                .Add(pool.CreateSystem<EventResolutionSystem>());
        }
    }
}
