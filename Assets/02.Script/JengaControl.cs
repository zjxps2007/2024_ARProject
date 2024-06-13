using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JengaControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameGUI;
    // Start is called before the first frame update
    void Start()
    {
        
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
