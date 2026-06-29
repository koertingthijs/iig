using UnityEngine;

public class ClickDebugger : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                Debug.Log("✅ Geraakt: " + hit.collider.gameObject.name);
            else
                Debug.Log("❌ Niets geraakt - klik mist alle colliders");
        }
    }
}
