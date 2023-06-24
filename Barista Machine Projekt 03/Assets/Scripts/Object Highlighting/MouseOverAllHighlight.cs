using UnityEngine;

public class MouseOverAllHighlight : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial = null;

    private Renderer[] renderers;
    private Material[][] defaultMaterials;

    private void Awake()
    {
        renderers = GetComponentsInChildren<Renderer>();

        defaultMaterials = new Material[renderers.Length][];

        for (int i = 0; i < renderers.Length; i++)
        {
            defaultMaterials[i] = renderers[i].materials;
        }
    }

    private void OnMouseEnter()
    {
        SetHighlightMaterial();
    }

    private void OnMouseExit()
    {
        RestoreDefaultMaterials();
    }

    private void SetHighlightMaterial()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            Material[] materials = new Material[renderers[i].materials.Length];

            for (int j = 0; j < materials.Length; j++)
            {
                materials[j] = highlightMaterial;
            }

            renderers[i].materials = materials;
        }
    }

    private void RestoreDefaultMaterials()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].materials = defaultMaterials[i];
        }
    }
}