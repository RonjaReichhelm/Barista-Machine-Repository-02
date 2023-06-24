using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        // Überprüfe, ob die Taste 1 gedrückt wird
        if (Input.GetKey(KeyCode.Alpha1))
        {
            // Rotiere das GameObject im Uhrzeigersinn
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        // Überprüfe, ob die Taste 2 gedrückt wird
        if (Input.GetKey(KeyCode.Alpha2))
        {
            // Rotiere das GameObject gegen den Uhrzeigersinn
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }
    }
}