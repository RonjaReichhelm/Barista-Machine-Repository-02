using UnityEngine;

public class MakeObjectInvisible : MonoBehaviour
{
    private Renderer objectRenderer;

    private void Start()
    {
        // Den Renderer des Objekts abrufen
        objectRenderer = GetComponent<Renderer>();
    }

    public void MakeInvisible()
    {
        // Den Renderer deaktivieren, um das Objekt unsichtbar zu machen
        objectRenderer.enabled = false;
    }

    public void MakeVisible()
    {
        // Den Renderer aktivieren, um das Objekt sichtbar zu machen
        objectRenderer.enabled = true;
    }
}