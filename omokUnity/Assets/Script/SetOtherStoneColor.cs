using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOtherStoneColor : MonoBehaviour
{
    // Start is called before the first frame update
    Color black = new Color(0.21f, 0.21f, 0.21f);
    void Start()
    {
        if (GameSingleton.Instance.GetStoneState() != PosState.Black)
        {
            GetComponent<SpriteRenderer>().color = black;
        }
        Destroy(this);
    }
}
