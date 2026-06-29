using UnityEngine;

public class FrameManager : MonoBehaviour
{
    public static FrameManager Instance;

    [Header("Frames (sleep hier je frame GameObjects in)")]
    public GameObject[] frames;

    [Header("Start frame index (0 = eerste frame)")]
    public int startFrameIndex = 0;

    private int currentFrameIndex = -1;

    void Awake()
    {
        // Singleton zodat andere scripts het makkelijk kunnen aanroepen
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        ShowFrame(startFrameIndex);
    }

    public void ShowFrame(int index)
    {
        for (int i = 0; i < frames.Length; i++)
            if (frames[i] != null) frames[i].SetActive(false);

        if (index >= 0 && index < frames.Length && frames[index] != null)
        {
            frames[index].SetActive(true);
            currentFrameIndex = index;

            // Camera meebewegen
            CameraFrameController cam = Camera.main.GetComponent<CameraFrameController>();
            if (cam != null) cam.MoveToFrame(index);
        }
    }

    public void NextFrame()
    {
        int next = (currentFrameIndex + 1) % frames.Length;
        ShowFrame(next);
    }

    public void PreviousFrame()
    {
        int prev = (currentFrameIndex - 1 + frames.Length) % frames.Length;
        ShowFrame(prev);
    }

    public int GetCurrentFrameIndex() => currentFrameIndex;
}