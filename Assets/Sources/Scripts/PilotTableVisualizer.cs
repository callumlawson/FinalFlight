using Entitas;

namespace Assets.Sources.Scripts
{
    public class PilotTableVisualizer : TableViewVisualizer
    {
        private void Awake()
        {
            EntitysToBeViewed = Matcher.AllOf(Matcher.Mood, Matcher.Name, Matcher.Health);
        }
    }
}
