using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    bool fix;
    int m;
    int n;
    Clinet clinet;
    CenterStoneColor stoneColor;
    void Start()
    {
        fix = false;
        m = 0;
        n = 0;
        clinet = GameObject.Find("GameManager").GetComponent<Clinet>();
        stoneColor = GameObject.Find("Turn").GetComponent<CenterStoneColor>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameSingleton.Instance.GetGiveUp())
        {
            Destroy(this.gameObject);
        }
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
                if (!GameSingleton.Instance.ContainPos(m,n))
                {
                    GameSingleton.Instance.AddStonePos(m, n);
                    fix = true;
                    SendPlay(m,n);
                    stoneColor.OtherTurn();
                    Destroy(this);
                }
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
}
