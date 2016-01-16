using Entitas;

namespace Assets.Sources.GameLogic.Mood
{
    public enum Mood
    {
        Invigorated,
        Depressed,
        Angry
    }

    public class MoodComponent : IComponent
    {
        public Mood Mood;
    }
}
