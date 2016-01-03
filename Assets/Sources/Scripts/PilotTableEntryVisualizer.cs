using Assets.Sources.GameLogic.Mood;
using UnityEngine.UI;

namespace Assets.Sources.Scripts
{
    public class PilotTableEntryVisualizer : UnityEngine.MonoBehaviour
    {
        public Text Name;
        public Text Helth;
        public Text Mood;

        public void UpdatePilotEntry(string name, float health, Mood mood)
        {
            Name.text = name;
            Helth.text = health.ToString();
            Mood.text = mood.ToString();
        }
    }
}
