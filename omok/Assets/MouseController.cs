using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (pos.x >=-7 && pos.x <= 7 && pos.y>=-7 && pos.y <= 7){
            pos = new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y),0);
        }
        else
        {
            pos = new Vector3(pos.x, pos.y, 0);
        }
        transform.position = pos;
    }
}
