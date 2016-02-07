using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent(typeof(Image))]
[AddComponentMenu("UI/Sprite Animation")]
public class UISpriteAnimation : MonoBehaviour
{
    [SerializeField] private Image targetImage;
    [SerializeField] private int FPS = 30;
    [SerializeField] private bool Loop = true;
    [SerializeField] private List<Sprite> Sprites = new List<Sprite>();

    private float delta;
    private int currentIndex;
    private bool active = true;

    /// <summary>
    /// Number of frames in the animation.
    /// </summary>
    public int frames
    {
        get { return Sprites.Count; }
    }

    /// <summary>
    /// Gets or sets the target image.
    /// </summary>
    /// <value>The target.</value>
    public Image TargetImaged
    {
        get { return targetImage; }
        set { targetImage = value; }
    }

    /// <summary>
    /// Animation framerate.
    /// </summary>
    public int FramesPerSecond
    {
        get { return FPS; }
        set { FPS = value; }
    }

    /// <summary>
    /// Set the animation to be looping or not
    /// </summary>
    public bool loop
    {
        get { return Loop; }
        set { Loop = value; }
    }

    /// <summary>
    /// Returns is the animation is still playing or not
    /// </summary>
    public bool isPlaying
    {
        get { return active; }
    }

    /// <summary>
    /// Advance the sprite animation process.
    /// </summary>
    void Update()
    {
        if (active && targetImage != null && Sprites.Count > 1)
        {
            delta += Time.deltaTime;
            var rate = 1f / FPS;

            if (rate < delta)
            {
                delta = (rate > 0f) ? delta - rate : 0f;

                if (++currentIndex >= Sprites.Count)
                {
                    currentIndex = 0;
                    active = Loop;
                }

                if (active)
                {
                    targetImage.overrideSprite = Sprites[currentIndex];
                }
            }
        }
    }

    /// <summary>
    /// Reset the animation to the beginning.
    /// </summary>
    public void Play()
    {
        active = true;
    }

    /// <summary>
    /// Pause the animation.
    /// </summary>
    public void Pause()
    {
        active = false;
    }

    public void SetPlaying(bool isPlaying)
    {
        active = isPlaying;
    }

    /// <summary>
    /// Reset the animation to frame 0 and activate it.
    /// </summary>
    public void ResetToBeginning()
    {
        active = true;
        currentIndex = 0;

        if (targetImage != null && Sprites.Count > 0)
        {
            targetImage.overrideSprite = Sprites[currentIndex];
        }
    }
}
