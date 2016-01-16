using Assets.Sources.GameLogic.Components;
using DG.Tweening;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Scripts
{
    public class EventVisualizer : UnityEngine.MonoBehaviour
    {
        public GameObject ChoiceButton;
        public Text Description;
        public Text Name;
        public GameObject UiView;

        public void Start()
        {
            var pool = Pools.pool;
            pool.GetGroup(Matcher.AllOf(Matcher.GameEvent)).OnEntityAdded +=
                (group, entity, index, component) => OnEventAdded(entity);
        }

        private void OnEventAdded(Entity entity)
        {
            if (entity.gameEvent.EventState == EventState.Presented)
            {
                UpdateEvent(entity.gameEvent.Title, entity.gameEvent.Description);
                UiView.SetActive(true);
            }
        }

        private void UpdateEvent(string title, string description)
        {
            Name.text = "";
            Description.text = "";
            Name.DOText(title, 1.0f).SetEase(Ease.Linear);
            Description.DOText(description, 2.0f).SetEase(Ease.Linear);
        }
    }
}