namespace Entitas {
    public partial class Pool {
        public ISystem CreateUINavigationSystem() {
            return this.CreateSystem<Assets.Sources.GameLogic.Systems.UINavigationSystem>();
        }
    }
}