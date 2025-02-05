using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody; // Referencia al cuerpo del jugador

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro de la pantalla
    }

    void Update()
    {
        // Captura el movimiento del ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotar hacia arriba y abajo (eje X de la cámara)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limita la rotación para evitar giros completos

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Aplica rotación a la cámara
        playerBody.Rotate(Vector3.up * mouseX); // Rotación horizontal del personaje
    }
}

