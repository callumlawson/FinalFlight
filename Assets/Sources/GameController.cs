using Assets.Sources.GameLogic;
using Assets.Sources.Init;
using Entitas;
using Entitas.Unity.VisualDebugging;
using UnityEngine;

namespace Assets.Sources.MonoBehaviour
{
    public class GameController : UnityEngine.MonoBehaviour
    {
        private Systems Systems;

        void Start()
        {
            Random.seed = 42;

            Systems = createSystems(Pools.pool);
            Systems.Initialize();
        }

        void Update()
        {
            Systems.Execute();
        }

        private Systems createSystems(Pool pool)
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
                .Add(pool.CreateSystem<TableViewSystem>());
        }
    }
}