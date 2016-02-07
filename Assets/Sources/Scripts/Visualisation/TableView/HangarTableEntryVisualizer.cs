using System.Globalization;
using Assets.Sources.GameLogic.Interfaces;
using Entitas;
using UnityEngine.UI;

namespace Assets.Sources.Scripts
{
    public class HangarTableEntryVisualizer : UnityEngine.MonoBehaviour, IEntityVisualizer
    {
        public Text Name;
        public Text Airspeed;
        public Text Condition;

        public void EntityUpdated(Entity entity)
        {
            Name.text = entity.name.Name;
            Airspeed.text = entity.airframe.MaxAirSpeed.ToString();
            Condition.text = entity.health.Health.ToString(CultureInfo.InvariantCulture);
        }
    }
}
