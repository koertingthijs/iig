using UnityEngine;

public class FreeMoveController : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;

    float rotationX = 0f;

    void Update()
    {
        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.parent.Rotate(Vector3.up * mouseX);

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // WASD movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.parent.forward * z + transform.parent.right * x;

        transform.parent.position += move * speed * Time.deltaTime;
    }
}