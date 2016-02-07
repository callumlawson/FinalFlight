using Entitas;
using Entitas.CodeGenerator;

namespace Assets.Sources.GameLogic.Meta
{
    public enum GameState
    {
        MainMenu,
        Barracks,
        Hangar,
        Event
    }

    [SingleEntity]
    public class GameStateComponent : IComponent
    {
        public GameState GameState;
    }
}
