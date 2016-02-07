using Assets.Sources.GameLogic.Events;
using Assets.Sources.GameLogic.Meta;
using Entitas;

namespace Assets.Sources.GameLogic.Systems
{
    public class UINavigationSystem : IInitializeSystem, ISetPool
    {
        private Pool systemPool;

        public void SetPool(Pool pool)
        {
            systemPool = pool;
        }

        public void Initialize()
        {
            UiEventHandler.NavigationEventReceived += NavigationEventReceived;
        }

        private void NavigationEventReceived(string navigationEvent)
        {
            switch (navigationEvent)
            {
                case "Barracks":
                    systemPool.ReplaceGameState(GameState.Barracks);
                    return;
                case "Hangar":
                    systemPool.ReplaceGameState(GameState.Hangar);
                    return;
            }
        }
    }
}
