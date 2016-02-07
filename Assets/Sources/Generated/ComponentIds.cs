public static class ComponentIds {
    public const int Airframe = 0;
    public const int Day = 1;
    public const int EventQueue = 2;
    public const int GameEvent = 3;
    public const int GameEventState = 4;
    public const int Paused = 5;
    public const int Time = 6;
    public const int Health = 7;
    public const int Description = 8;
    public const int GameState = 9;
    public const int Mood = 10;
    public const int Name = 11;
    public const int Resource = 12;
    public const int View = 13;

    public const int TotalComponents = 14;

    public static readonly string[] componentNames = {
        "Airframe",
        "Day",
        "EventQueue",
        "GameEvent",
        "GameEventState",
        "Paused",
        "Time",
        "Health",
        "Description",
        "GameState",
        "Mood",
        "Name",
        "Resource",
        "View"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Assets.Sources.GameLogic.Components.AirframeComponent),
        typeof(Assets.Sources.GameLogic.Components.DayComponent),
        typeof(Assets.Sources.GameLogic.Components.EventQueueComponent),
        typeof(Assets.Sources.GameLogic.Components.GameEventComponent),
        typeof(Assets.Sources.GameLogic.Components.GameEventStateComponent),
        typeof(Assets.Sources.GameLogic.Components.PausedComponent),
        typeof(Assets.Sources.GameLogic.Components.TimeComponent),
        typeof(Assets.Sources.GameLogic.Health.HealthComponent),
        typeof(Assets.Sources.GameLogic.Meta.DescriptionComponent),
        typeof(Assets.Sources.GameLogic.Meta.GameStateComponent),
        typeof(Assets.Sources.GameLogic.Mood.MoodComponent),
        typeof(Assets.Sources.GameLogic.Name.NameComponent),
        typeof(ResourceComponent),
        typeof(ViewComponent)
    };
}