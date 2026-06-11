using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    [Header("Naar welk frame navigeren bij klik?")]
    public int targetFrameIndex = 0;

    [Header("Of gebruik 'next' / 'previous' navigatie")]
    public bool useNext = false;
    public bool usePrevious = false;

    [Header("Visuele feedback (optioneel)")]
    public Color hoverColor = Color.yellow;
    private Color originalColor;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
            originalColor = rend.material.color;

        // Zorg dat het object een collider heeft voor klik-detectie
        if (GetComponent<Collider>() == null)
            Debug.LogWarning($"{gameObject.name} heeft geen Collider — klikken werkt niet!");
    }

    void OnMouseDown()
    {
        if (FrameManager.Instance == null)
        {
            Debug.LogError("Geen FrameManager gevonden in de scene!");
            return;
        }

        if (useNext)
            FrameManager.Instance.NextFrame();
        else if (usePrevious)
            FrameManager.Instance.PreviousFrame();
        else
            FrameManager.Instance.ShowFrame(targetFrameIndex);
    }

    // Hover feedback
    void OnMouseEnter()
    {
        if (rend != null)
            rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        if (rend != null)
            rend.material.color = originalColor;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("Raak: " + hit.collider.gameObject.name);
            }
        }
    }
}
