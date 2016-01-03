namespace Entitas {
    public partial class Pool {
        public ISystem CreateStartGameSystem() {
            return this.CreateSystem<Assets.Sources.Init.StartGameSystem>();
        }
    }
}