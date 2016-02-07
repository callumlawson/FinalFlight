namespace Entitas {
    public partial class Pool {
        public ISystem CreateEventResolutionSystem() {
            return this.CreateSystem<Assets.Sources.GameLogic.Systems.EventPredicateCheckingSystem>();
        }
    }
}