using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitMark : MonoBehaviour
{
    public int speed = 5;
    Image img;
    float rot = 0;
    RectTransform rc;
    bool fill = true;
    void Start()
    {
        rc = GetComponent<RectTransform>();
        img = GetComponent<Image>();    
    }

    // Update is called once per frame
    void Update()
    {
        rot += speed *3;
        if (rot >= 360)
        {
            rot = 0;
        }
        rc.eulerAngles = new Vector3(0, 0, -rot);
        if (fill)
        {
            img.fillAmount += Time.deltaTime * speed;
            if (img.fillAmount >= 1f)
            {
                img.fillAmount = 1f;
                img.fillClockwise = false;
                fill = false;
            }
        }
        else
        {
            img.fillAmount -= Time.deltaTime * speed;
            if (img.fillAmount <= 0f)
            {
                img.fillAmount = 0f;
                img.fillClockwise = true;
                fill = true;
            }
        }
        
    }
}
