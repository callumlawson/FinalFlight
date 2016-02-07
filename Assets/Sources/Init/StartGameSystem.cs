using Assets.Sources.GameLogic.Events;
using Assets.Sources.GameLogic.Meta;
using Entitas;

namespace Assets.Sources.Init
{
    class StartGameSystem : IInitializeSystem, ISetPool
    {
        private Pool ourPool;

        public void Initialize()
        {
            ourPool.SetGameState(GameState.MainMenu);
            ourPool.SetTime(0);
        }

        public void SetPool(Pool pool)
        {
            ourPool = pool;
        }
    }
}
