using System.Globalization;
using DG.Tweening;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Scripts.Visualisation
{
    class TimeVisualizer : UnityEngine.MonoBehaviour
    {
        [SerializeField] private Text TimeText;
        [SerializeField] private UISpriteAnimation Animation;

        private int lastTime;

        public void Start()
        {
            var pool = Pools.pool;

            pool.GetGroup(Matcher.Day).OnEntityAdded +=
                (group, entity, index, component) => OnTimeUpdated(pool.day.Day);

            pool.GetGroup(Matcher.Paused).OnEntityAdded +=
                (group, entity, index, component) => OnPausedUpdated(true);

            pool.GetGroup(Matcher.Paused).OnEntityRemoved +=
                (group, entity, index, component) => OnPausedUpdated(false);
        }

        private void OnTimeUpdated(int day)
        {
                TimeText.text = day.ToString(CultureInfo.InvariantCulture);
                TimeText.rectTransform.DOPunchScale(new Vector3(1.2f, 1.2f, 1.2f), 1.0f, 0);
        }

        private void OnPausedUpdated(bool isPaused)
        {
            Animation.SetPlaying(!isPaused);
        }
    }
}
