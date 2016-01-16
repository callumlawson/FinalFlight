using UnityEngine;

namespace Assets.Sources.Scripts
{
    public class UIDirectory : UnityEngine.MonoBehaviour
    {
        private static UIDirectory Instance;

        public RectTransform EventUI;
        public RectTransform EventView;

        public void Awake()
        {
            Instance = this;
        }

        public static UIDirectory GetInstace()
        {
            return Instance;
        }
    }
}
