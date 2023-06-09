using UnityEngine;

public class SiebRotateAndMove : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float movementSpeed = 1f;
    public bool rotateEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (rotateEnabled)
        {
            // Check for '2' key press to rotate left
            if (Input.GetKey(KeyCode.Alpha2))
            {
                // Rotate the object around the Y-axis in the opposite direction
                transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
            }

            // Check for '1' key press to rotate right
            if (Input.GetKey(KeyCode.Alpha1))
            {
                // Rotate the object around the Y-axis
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            }

            // Check for '3' key press to move up
            if (Input.GetKey(KeyCode.Alpha3))
            {
                // Move the object up along the Y-axis
                transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
            }

            // Check for '4' key press to move down
            if (Input.GetKey(KeyCode.Alpha4))
            {
                // Move the object down along the Y-axis
                transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
            }
        }
    }
}