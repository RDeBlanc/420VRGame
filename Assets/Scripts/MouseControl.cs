using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction, Color.blue,Mathf.Infinity);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity)) {

            transform.position = hit.point;

        }    
    }
}
