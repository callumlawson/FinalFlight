namespace Entitas {
    public partial class Pool {
        public ISystem CreateCreateAircraftSystem() {
            return this.CreateSystem<Assets.Sources.Init.CreateAircraftSystem>();
        }
    }
}