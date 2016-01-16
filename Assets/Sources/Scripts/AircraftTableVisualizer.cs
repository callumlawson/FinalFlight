using Entitas;

namespace Assets.Sources.Scripts
{
    public class AircraftTableVisualizer : TableViewVisualizer
    {
        private void Awake()
        {
            EntitysToBeViewed = Matcher.AllOf(Matcher.Name, Matcher.Airframe, Matcher.Health);
        }
    }
}
