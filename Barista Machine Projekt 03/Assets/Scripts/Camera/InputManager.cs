using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;

    public static InputManager Instance{

    get {
        return _instance;
    }
}

private PlayerControls playerControls; // Eine private Variable vom Typ PlayerControls

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        playerControls = new PlayerControls(); // Erstellt eine neue Instanz von PlayerControls
      //  Cursor.visible = false; // Versteckt die Maus
    }

    private void OnEnable()
    {
        playerControls.Enable(); // Aktiviert die Eingabesteuerung von PlayerControls
    }

    private void OnDisable()
    {
        playerControls.Disable(); // Deaktiviert die Eingabesteuerung von PlayerControls
    }

    public Vector2 GetPlayerMovement() // Dies repräsentiert die Spielerbewegung.
    {
        return playerControls.Player.Movement.ReadValue<Vector2>(); // Gibt den Wert der Eingabesteuerung "Look" des "playerControls.Player"-Objekts als Vector2 zurück. 
    }

    public Vector2 GetMouseDelta() // Dies repräsentiert die Mausbewegung (Änderung der Mausposition).
    {
        return playerControls.Player.Look.ReadValue<Vector2>(); // Gibt den Wert der Eingabesteuerung "Look" des "playerControls.Player"-Objekts als Vector2 zurück.
    }

    public bool PlayerJumpedThisFrame()
    {
        return playerControls.Player.Jump.triggered;
    }
    
}