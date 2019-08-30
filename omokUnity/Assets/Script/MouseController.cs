using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    bool fix;
    int m;
    int n;
    bool triggerOthers;
    public Clinet clinet;
    void Start()
    {
        fix = false;
        m = 0;
        n = 0;
        clinet = GameObject.Find("GameManager").GetComponent<Clinet>();
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

            if (Input.GetMouseButton(0) && inGrid == true)
            {
                m = -(int)pos.y + 7;
                n = (int)pos.x + 7;
                if (!triggerOthers)
                {
                    fix = true;
                    SendPlay(m,n);
                    Destroy(this);
                }
                //if setStone is available
                //if (GetComponentInParent<StonePositionSetting>().SetStone(state, m, n)) {
                //    fix = true;
                //    Destroy(this);
                //}
            }
        }
    }
    void SendPlay(int m, int n) {
        Play play = new Play();
        play.m = m;
        play.n = n;
        string str = JsonUtility.ToJson(play);
        clinet.SendMsg(str);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
        {
            triggerOthers = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
        {
            if (!triggerOthers)
            {
                triggerOthers = true;
            }
        }
    }
}
