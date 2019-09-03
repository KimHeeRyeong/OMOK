using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStone : MonoBehaviour
{
    public GameObject myStone;
    public GameObject otherStone;

    private void Update()
    {
        if(GameSingleton.Instance.CheckMyTurn()){
            GameSingleton.Instance.ChangeMyTurn();
            InstantiateStone();
        }
    }
    void InstantiateStone()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(myStone, pos, transform.rotation, transform);
    }
    public void InstantiateOtherStone(int m, int n) {
        Vector3 pos = new Vector3(n - 7,7 - m, 0);
        GameSingleton.Instance.AddStonePos(m, n);
        Instantiate(otherStone, pos, transform.rotation, transform);
    }
}
