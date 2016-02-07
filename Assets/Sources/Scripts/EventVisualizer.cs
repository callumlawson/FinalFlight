using System.Collections.Generic;
using System.Linq;
using Assets.Sources.GameLogic.Components;
using DG.Tweening;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Scripts
{
    public class EventVisualizer : UnityEngine.MonoBehaviour
    {
        public GameObject OptionButton;
        public Text Description;
        public Text Name;
        public GameObject UiView;
        public RectTransform OptionParent;

        private List<GameObject> PreviousOptions;
        private GameEventComponent CurrentGameEvent;

        public void Start()
        {
            PreviousOptions = new List<GameObject>();
            var pool = Pools.pool;
            pool.GetGroup(Matcher.AllOf(Matcher.GameEvent, Matcher.GameEventState)).OnEntityAdded +=
                (group, entity, index, component) => OnEventAdded(entity);
        }

        private void OnEventAdded(Entity eventEntity)
        {
            var eventEntities = Pools.pool.GetGroup(Matcher.AllOf(Matcher.GameEvent, Matcher.GameEventState)).GetEntities();
            var possibleEventToDisplay = eventEntities.FirstOrDefault(entity => entity.gameEventState.EventState == EventState.Presented);

            if (possibleEventToDisplay != null && possibleEventToDisplay.gameEvent != CurrentGameEvent)
            {
                CurrentGameEvent = possibleEventToDisplay.gameEvent;
                UpdateEvent(possibleEventToDisplay.gameEvent);
                UiView.SetActive(true);
            }
            else if (possibleEventToDisplay == null)
            {
                CurrentGameEvent = null;
                UiView.SetActive(false);
            }
        }

        private void UpdateEvent(GameEventComponent gameEvent)
        {
            Name.text = "";
            Description.text = "";
            Name.DOText(gameEvent.Title, 0.5f).SetEase(Ease.Linear);
            Description.DOText(gameEvent.Description, 1.0f).SetEase(Ease.Linear);

            PreviousOptions.ForEach(eventOption => {
                PreviousOptions.Remove(eventOption);
                Destroy(eventOption);
            });

            foreach (var eventOption in gameEvent.EventOptions)
            {
                var optionButton = Instantiate(OptionButton);
                optionButton.GetComponent<OptionButtonVisualizer>().SetupOptionButton(eventOption);
                optionButton.transform.SetParent(OptionParent);
                PreviousOptions.Add(optionButton);
            }
        }
    }
}