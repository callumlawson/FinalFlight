namespace Entitas {
    public partial class Pool {
        public ISystem CreateGameEventSystem() {
            return this.CreateSystem<Assets.Sources.GameLogic.Systems.GameEventSystem>();
        }
    }
}