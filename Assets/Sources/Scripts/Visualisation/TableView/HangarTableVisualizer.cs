using Assets.Sources.GameLogic.Meta;
using Entitas;

namespace Assets.Sources.Scripts
{
    public class HangarTableVisualizer : TableViewVisualizer
    {
        private void Awake()
        {
            EntitysToBeViewed = Matcher.AllOf(Matcher.Name, Matcher.Airframe, Matcher.Health);
            GameStateWhenVisible = GameState.Hangar;
        }
    }
}
