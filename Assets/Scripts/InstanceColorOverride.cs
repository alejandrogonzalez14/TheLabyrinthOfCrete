using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteAlways]
[RequireComponent(typeof(Renderer))]
public class InstanceColorOverride : MonoBehaviour
{
    [ColorUsage(true, true)]
    public Color instanceColor = Color.white;

    private Material runtimeMaterial;

    private Renderer _renderer;

    void OnEnable()
    {
        _renderer = GetComponent<Renderer>();
        ApplyColor();
    }

    void OnValidate()
    {
        ApplyColor();
    }

    private void ApplyColor()
    {
        if (_renderer == null) return;

        // Only assign a new material if we don't already have one
        if (Application.isPlaying)
        {
            // In play mode, clone material only once
            if (runtimeMaterial == null)
            {
                runtimeMaterial = new Material(_renderer.sharedMaterial);
                _renderer.material = runtimeMaterial;
            }

            runtimeMaterial.SetColor("_BaseColor", instanceColor);
        }
        else
        {
#if UNITY_EDITOR
            // In edit mode, avoid cloning endlessly — track via sharedMaterial name
            if (_renderer.sharedMaterial != null && !_renderer.sharedMaterial.name.Contains("(Instance)"))
            {
                runtimeMaterial = new Material(_renderer.sharedMaterial);
                runtimeMaterial.name += " (Instance)";
                _renderer.sharedMaterial = runtimeMaterial;
            }

            if (_renderer.sharedMaterial != null)
            {
                _renderer.sharedMaterial.SetColor("_BaseColor", instanceColor);
            }
#endif
        }
    }
}
