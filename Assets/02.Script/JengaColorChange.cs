using UnityEngine;

public class JengaColorChange : MonoBehaviour
{
    private Color newColor;
    private Renderer newRenderer;
    private Rigidbody _rigidbody;
    
    // Start is called before the first frame update

    private void Awake()
    {
        newColor = Random.ColorHSV();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        newRenderer = GetComponent<Renderer>();
        newRenderer.material.color = newColor;
    }
}
