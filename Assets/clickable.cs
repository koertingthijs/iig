using UnityEngine;

public class ModeButton : MonoBehaviour
{
    public ModeManager modeManager;
    public enum ModeAction { SetFrameMode, SetFreeMode }
    public ModeAction modeAction;

    void OnMouseDown()
    {
        if (modeManager == null)
        {
            Debug.LogError("Geen ModeManager toegewezen!");
            return;
        }

        if (modeAction == ModeAction.SetFreeMode)
            modeManager.SetFreeMode();
        else
            modeManager.SetFrameMode();
    }
}