using System.Globalization;
using Assets.Sources.GameLogic.Interfaces;
using Entitas;
using UnityEngine.UI;

namespace Assets.Sources.Scripts
{
    public class PilotTableEntryVisualizer : UnityEngine.MonoBehaviour, IEntityVisualizer
    {
        public Text Name;
        public Text Helth;
        public Text Mood;

        public void EntityUpdated(Entity entity)
        {
            Name.text = entity.name.Name;
            Helth.text = entity.health.Health.ToString(CultureInfo.InvariantCulture);
            Mood.text = entity.mood.Mood.ToString();
        }
    }
}
