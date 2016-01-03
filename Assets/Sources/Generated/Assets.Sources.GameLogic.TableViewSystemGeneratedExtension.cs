namespace Entitas {
    public partial class Pool {
        public ISystem CreateTableViewSystem() {
            return this.CreateSystem<Assets.Sources.GameLogic.TableViewSystem>();
        }
    }
}