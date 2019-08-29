﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    bool fix;
    // Start is called before the first frame update
    void Start()
    {
        fix = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!fix)
        {
            //stone position preview
            bool inGrid = false;
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (pos.x >= -7 && pos.x <= 7 && pos.y >= -7 && pos.y <= 7)
            {
                pos = new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), 0);
                inGrid = true;
            }
            else
            {
                pos = new Vector3(pos.x, pos.y, 0);
            }
            transform.position = pos;

            if (Input.GetMouseButtonDown(0) && inGrid == true)
            {
                //if setStone is available
                if (GetComponentInParent<StonePositionSetting>().SetStone(PosState.White, -(int)pos.y + 7, (int)pos.x + 7)) {
                    fix = true;
                    Destroy(this);
                }
            }
        }
    }
    private void OnDestroy()
    {
        GetComponentInParent<AddStone>().InstantiateStone();
    }
}
