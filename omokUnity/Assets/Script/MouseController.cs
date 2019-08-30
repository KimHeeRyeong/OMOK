using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    bool fix;
    int m;
    int n;
    PosState state;
    // Start is called before the first frame update
    void Start()
    {
        fix = false;
        m = 0;
        n = 0;
        state = GameSingleton.Instance.GetStoneState();
        if (state == PosState.Black)
        {
            GetComponent<SpriteRenderer>().color = Color.black;
        }
    }

    // Update is called once per frame
    void Update()
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
                //if setStone is available
                if (GetComponentInParent<StonePositionSetting>().SetStone(state, m, n)) {
                    fix = true;
                    GameSingleton.Instance.SendFixPos(m, n);
                    Destroy(this);
                }
            }
        }
    }
    private void OnDestroy()
    {
        if (GetComponentInParent<Transform>() != null)
        {
            GetComponentInParent<CheckClear>().CheckOMOK(state, m, n);
        }
    }
}
