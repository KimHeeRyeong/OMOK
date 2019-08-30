using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStone : MonoBehaviour
{
    public GameObject myStone;
    public GameObject otherStone;
    
    int numStone;

    void Start()
    {
        numStone = 0;
    }
    private void Update()
    {
        if(GameSingleton.Instance.CheckMyTurn()){
            GameSingleton.Instance.ChangeMyTurn(false);
            InstantiateStone();
        }
    }
    public void InstantiateStone()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(myStone, pos, transform.rotation, transform);
        numStone++;
    }
    public void InstantiateOtherStone(int m, int n) {
        PosState state = PosState.None;
        if (GameSingleton.Instance.GetStoneState() == PosState.Black){
            state = PosState.White;
        }
        else if(GameSingleton.Instance.GetStoneState() == PosState.White)
        {
            state = PosState.Black;
        }
        Vector3 pos = new Vector3( n - 7,7 - m, 0);
        GetComponentInParent<StonePositionSetting>().SetStone(state, m, n);
        Instantiate(otherStone, pos, transform.rotation, transform);
        numStone++;
    }
}
