namespace Entitas {
    public partial class Pool {
        public ISystem CreateCreateEventsSystem() {
            return this.CreateSystem<Assets.Sources.Init.CreateEventsSystem>();
        }
    }
}