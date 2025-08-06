using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color[] colors;
    public Texture[] textures;

    private int index = 0;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        if (colors == null || colors.Length == 0)
        {
            Debug.LogWarning("Colors array is empty or not assigned! Please assign colors in the inspector.");
        }

        if (textures == null)
        {
            Debug.LogWarning("Textures array is not assigned! Assign it or leave it empty.");
        }
    }

    public void ChangeColor()
    {
        if (colors == null || colors.Length == 0)
        {
            Debug.LogWarning("Colors array is empty! Cannot change color.");
            return;
        }

        index = (index + 1) % colors.Length;
        rend.material.color = colors[index];

        if (textures != null && textures.Length > 0 && index < textures.Length)
        {
            rend.material.mainTexture = textures[index];
        }
        else if (textures != null && textures.Length > 0)
        {
            // Optional: Clear texture if no texture at this index
            rend.material.mainTexture = null;
        }
    }
}

