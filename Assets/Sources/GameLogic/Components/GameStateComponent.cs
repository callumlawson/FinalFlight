using Entitas;
using Entitas.CodeGenerator;

namespace Assets.Sources.GameLogic.Meta
{
    public enum GameState
    {
        MainMenu,
        Pilots,
        Hangar
    }

    [SingleEntity]
    public class GameStateComponent : IComponent
    {
        public GameState GameState;
    }
}
