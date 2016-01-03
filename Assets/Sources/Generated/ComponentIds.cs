public static class ComponentIds {
    public const int Health = 0;
    public const int GameState = 1;
    public const int Mood = 2;
    public const int Name = 3;
    public const int Resource = 4;
    public const int View = 5;

    public const int TotalComponents = 6;

    public static readonly string[] componentNames = {
        "Health",
        "GameState",
        "Mood",
        "Name",
        "Resource",
        "View"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Assets.Sources.GameLogic.Health.HealthComponent),
        typeof(Assets.Sources.GameLogic.Meta.GameStateComponent),
        typeof(Assets.Sources.GameLogic.Mood.MoodComponent),
        typeof(Assets.Sources.GameLogic.Name.NameComponent),
        typeof(ResourceComponent),
        typeof(ViewComponent)
    };
}