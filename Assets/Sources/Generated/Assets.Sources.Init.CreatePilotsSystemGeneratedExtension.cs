namespace Entitas {
    public partial class Pool {
        public ISystem CreateCreatePilotsSystem() {
            return this.CreateSystem<Assets.Sources.Init.CreatePilotsSystem>();
        }
    }
}