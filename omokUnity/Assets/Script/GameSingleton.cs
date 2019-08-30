using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleton : MonoBehaviour
{
    private static GameSingleton instance;
    public static GameSingleton Instance { get => instance; }

    PosState myState;
    bool myTurn;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        myState = PosState.None;
        myTurn = false;
    }

    public PosState GetStoneState() {
        return myState;
    }
    public bool SetStoneState(PosState state) {
        if (myState == PosState.None)
        {
            myState = state;
            if (myState == PosState.Black)
            {
                myTurn = true;
            }
            else
            {
                myTurn = false;
            }
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckMyTurn() {
        return myTurn;
    }
    public void ChangeMyTurn() {
        myTurn = !myTurn;
    }
}
