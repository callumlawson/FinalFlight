using Assets.Sources.GameLogic.Meta;
using Entitas;

namespace Assets.Sources.Scripts
{
    public class BarracksTableVisualizer : TableViewVisualizer
    {
        private void Awake()
        {
            EntitysToBeViewed = Matcher.AllOf(Matcher.Mood, Matcher.Name, Matcher.Health);
            GameStateWhenVisible = GameState.Barracks;
        }
    }
}
