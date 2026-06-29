using UnityEngine;

public class CameraFrameController : MonoBehaviour
{
    [System.Serializable]
    public class CameraPosition
    {
        public string frameName;
        public Transform target; // Sleep hier een leeg GameObject in
    }

    public CameraPosition[] positions;
    public float transitionSpeed = 2f; // 0 = direct, hoger = sneller

    private Transform targetTransform;

    void Start()
    {
        // Start op positie 0
        if (positions.Length > 0 && positions[0].target != null)
        {
            transform.position = positions[0].target.position;
            transform.rotation = positions[0].target.rotation;
            targetTransform = positions[0].target;
        }
    }

    void Update()
    {
        if (targetTransform != null)
        {
            // Vloeiende beweging naar target
            transform.position = Vector3.Lerp(transform.position, targetTransform.position, Time.deltaTime * transitionSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetTransform.rotation, Time.deltaTime * transitionSpeed);
        }
    }

    public void MoveToFrame(int frameIndex)
    {
        if (frameIndex >= 0 && frameIndex < positions.Length && positions[frameIndex].target != null)
            targetTransform = positions[frameIndex].target;
    }
}
