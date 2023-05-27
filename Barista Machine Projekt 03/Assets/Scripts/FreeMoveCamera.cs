using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Camera))]

public class FreeMoveCamera : MonoBehaviour
{
  [SerializeField] private float moveSpeed = 100f; //Bewegungsgeschewindigkeit einstellen
  [SerializeField] private float rotationSpeed = 2f; //Rotationsgeschwindigkeit einstellen

  private Camera cam;

  // CamerPan
  [SerializeField] private float panSpeed = 5f; //Geschwindigkeit
  private Vector3 lastPanPosition; //letzter Punkt der Maus, bevor panning beginnt

  //Camera Resetten: Variablen deklarieren
  private Vector3 startPosition;
  private Quaternion startRotation;
  private void Start()
  {
      startPosition = transform.position;
      startRotation = transform.rotation;
  }

  private void Awake() => cam = Camera.main; //Referenzen auf Camera

  private void LateUpdate()
  {
      RotateCamera();
      MoveCamera();
      PanCamera();

      if (Input.GetKeyDown(KeyCode.X))
      {
          ResetCamera();
      }

  }

  private void RotateCamera()
  {
      if (!Input.GetMouseButton(1))
          return;

      var yaw = Input.GetAxis("Mouse X");
      var pitch = Input.GetAxis("Mouse Y");
      var rotateValue = new Vector3(pitch, -yaw, 0) * rotationSpeed;
      cam.transform.eulerAngles -= rotateValue;

  }

  private void MoveCamera()
  {
      var move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
      move = Vector3.ClampMagnitude(move, moveSpeed); // Magnitude des Vektors begrenzen für richtige Geschwindigekeit
      move *= Time.deltaTime;
      cam.transform.Translate(move, Space.Self);
  }

  private void ResetCamera()
  {
      transform.position = startPosition;
      transform.rotation = startRotation;
  }

  private void PanCamera()
  {
      if (Input.GetMouseButtonDown(2))
          lastPanPosition = Input.mousePosition; //aktuelle Mausposition als aktuelle Mausposition setzen
      if (Input.GetMouseButton(2))
      {
          Vector3 offset = cam.ScreenToViewportPoint(lastPanPosition - Input.mousePosition); //Bewegung im 2D Raum
          Vector3 move = new Vector3(offset.x, offset.y, 0) * panSpeed; //Bewegung im 3D Raum (ohne Z-Achse)
        
          cam.transform.Translate(move, Space.Self);
          lastPanPosition = Input.mousePosition;
      }
  }

}
