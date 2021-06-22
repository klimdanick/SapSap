using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileSelection : MonoBehaviour
{
    bool selected = false;
    Vector3 beginTransform;
    // Start is called before the first frame update
    void Start()
    {
        beginTransform = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if(Physics.Raycast (ray, out hit))
        {
            if(hit.transform == gameObject.transform) {
                if (Input.GetMouseButtonDown(0)) {
                    if (!selected) {
                        selected=true;
                        gameObject.transform.position = beginTransform + new Vector3(0, 1, 0);
                    } else {
                        selected=false; 
                        gameObject.transform.position = beginTransform;
                    }
                }
            } else if (Input.GetMouseButtonDown(0)) {
                selected=false; 
                gameObject.transform.position = beginTransform;
            }
        } else if (Input.GetMouseButtonDown(0)) { 
                selected=false; 
                gameObject.transform.position = beginTransform;
        }

        if (selected) {
            //gameObject.transform.Translate(0, 0.1, 0);
        }
    }
}
//