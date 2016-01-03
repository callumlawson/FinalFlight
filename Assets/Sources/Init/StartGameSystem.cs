using Assets.Sources.GameLogic.Meta;
using Entitas;

namespace Assets.Sources.Init
{
    class StartGameSystem : IInitializeSystem, ISetPool
    {
        private Pool ourPool;

        public void Initialize()
        {
            ourPool.SetGameState(GameState.Pilots);
        }

        public void SetPool(Pool pool)
        {
            ourPool = pool;
        }
    }
}
