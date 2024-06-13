using TMPro;
using UnityEngine;

public class JengaControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameGUI;
    private LineRenderer _lineRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.widthMultiplier = 0.1f;
        _lineRenderer.startColor = Color.green;
        _lineRenderer.endColor = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 8))
        {
            gameGUI.text = hit.transform.gameObject.name;
        }
    }
}
