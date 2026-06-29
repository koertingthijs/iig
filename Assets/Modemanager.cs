using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public GameObject startScreenFrame; // sleep hier Frame 1 in
    public MonoBehaviour freeMoveScript;

    void Start()
    {
        SetFrameMode();
    }

    public void SetFrameMode()
    {
        startScreenFrame.SetActive(true);
        freeMoveScript.enabled = false;
    }

    public void SetFreeMode()
    {
        startScreenFrame.SetActive(false);
        freeMoveScript.enabled = true;
    }
}