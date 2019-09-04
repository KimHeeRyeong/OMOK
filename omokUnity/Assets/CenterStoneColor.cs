using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenterStoneColor : MonoBehaviour
{
    Text tx;
    Image img;
    Color black = new Color(0.21f, 0.21f, 0.21f);
    // Start is called before the first frame update
    void Start()
    {
        tx = GetComponentInChildren<Text>();
        tx.gameObject.SetActive(false);
        img = GetComponent<Image>();
        img.color = black;
    }
    public void ResetTurn()
    {
        tx.gameObject.SetActive(false);
        img.color = black;
    }
    public void MyTurn() {
        if (GameSingleton.Instance.GetStoneState() == PosState.White)
        {
            img.color = Color.white;
            tx.color = black;
        }
        else
        {
            img.color = black;
            tx.color = Color.white;
        }
        tx.gameObject.SetActive(true);
    }
    public void OtherTurn() {
        if (GameSingleton.Instance.GetStoneState() == PosState.White)
        {
            img.color = Color.black;
        }
        else
        {
            img.color = Color.white;
        }
        tx.gameObject.SetActive(false);
    }
}
