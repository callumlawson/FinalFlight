using Assets.Sources.GameLogic.Components;
using Assets.Sources.GameLogic.Events;
using UnityEngine;
using UnityEngine.UI;

public class OptionButtonVisualizer : MonoBehaviour
{
    public Text Description;
    public UIButtonExtended Button;

    public void SetupOptionButton(EventOption eventOption)
    {
        Description.text = eventOption.OptionDescription;
        Button.onClick.AddListener(() => UiEventHandler.FireOptionSelectedEvent(eventOption));
    }
}
