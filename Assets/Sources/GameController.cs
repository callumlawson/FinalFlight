using Assets.Sources.Init;
using Entitas;
using UnityEngine;

namespace Assets.Sources.MonoBehaviour
{
    public class GameController : UnityEngine.MonoBehaviour
    {
        private Systems systems;

        private void Start()
        {
            Random.seed = 42;
            systems = ActiveSystems.GetSystems(Pools.pool);
            systems.Initialize();
        }

        private void Update()
        {
            systems.Execute();
        }
    }
}