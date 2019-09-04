using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneImageOther : MonoBehaviour
{
    Image img;
    Color black = new Color(0.21f, 0.21f, 0.21f);
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        img.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameSingleton.Instance.GetStoneState() != PosState.None && !img.enabled)
        {
            if (GameSingleton.Instance.GetStoneState() == PosState.Black)
            {
                img.color = Color.white;
            }
            else
            {
                img.color = black;
            }
            img.enabled = true;
        }
        else if (GameSingleton.Instance.GetStoneState() == PosState.None && img.enabled)
        {
            img.enabled = false;
        }
    }
}
