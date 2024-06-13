using System.Collections;
using System.Collections.Generic;
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
        DrawRay();
        
        Ray ray = Camera.main.ScreenPointToRay(transform.forward);
        RaycastHit hit;
        
        

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 8))
        {
            gameGUI.text = hit.transform.gameObject.name;
        }
    }
    
    void DrawRay()
    {
        // 화면 중앙 계산
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        // 카메라 공간에서 월드 공간으로 변환
        Vector3 worldStartPoint = Camera.main.ScreenToWorldPoint(new Vector3(screenCenter.x, screenCenter.y, Camera.main.nearClipPlane));
        Vector3 worldEndPoint = Camera.main.ScreenToWorldPoint(new Vector3(screenCenter.x, screenCenter.y, Camera.main.nearClipPlane + 10));

        // LineRenderer를 사용해 레이 그리기
        _lineRenderer.SetPosition(0, worldStartPoint);
        _lineRenderer.SetPosition(1, worldEndPoint);
    }
}
