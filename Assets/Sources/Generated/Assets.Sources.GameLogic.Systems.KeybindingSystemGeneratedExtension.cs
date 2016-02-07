namespace Entitas {
    public partial class Pool {
        public ISystem CreateKeybindingSystem() {
            return this.CreateSystem<Assets.Sources.GameLogic.Systems.KeybindingSystem>();
        }
    }
}