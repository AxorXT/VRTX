using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Asigna la cápsula (jugador) aquí
    public float mouseSensitivity = 200f; // Aumenta la sensibilidad del ratón
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor al centro
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX); // Rotar el jugador
    }
}
