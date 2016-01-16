public static class ComponentIds {
    public const int Airframe = 0;
    public const int EventQueue = 1;
    public const int GameEvent = 2;
    public const int Health = 3;
    public const int Description = 4;
    public const int GameState = 5;
    public const int Time = 6;
    public const int Mood = 7;
    public const int Name = 8;
    public const int Resource = 9;
    public const int View = 10;

    public const int TotalComponents = 11;

    public static readonly string[] componentNames = {
        "Airframe",
        "EventQueue",
        "GameEvent",
        "Health",
        "Description",
        "GameState",
        "Time",
        "Mood",
        "Name",
        "Resource",
        "View"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Assets.Sources.GameLogic.Components.AirframeComponent),
        typeof(Assets.Sources.GameLogic.Components.EventQueueComponent),
        typeof(Assets.Sources.GameLogic.Components.GameEventComponent),
        typeof(Assets.Sources.GameLogic.Health.HealthComponent),
        typeof(Assets.Sources.GameLogic.Meta.DescriptionComponent),
        typeof(Assets.Sources.GameLogic.Meta.GameStateComponent),
        typeof(Assets.Sources.GameLogic.Meta.TimeComponent),
        typeof(Assets.Sources.GameLogic.Mood.MoodComponent),
        typeof(Assets.Sources.GameLogic.Name.NameComponent),
        typeof(ResourceComponent),
        typeof(ViewComponent)
    };
}