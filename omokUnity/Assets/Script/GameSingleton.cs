﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameSingleton : MonoBehaviour
{
    private static GameSingleton instance;
    public static GameSingleton Instance { get => instance; }

    PosState myState;
    bool myTurn;
    int[,] setPos;
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
        setPos = new int[15,15];
        ClearPan();
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
    public void ClearPan() {
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                setPos[i, j] = 0;
            }
        }
    }
    public void AddStonePos(int m, int n) {
        Debug.Log(m + "" + n);
        setPos[m, n] = 1;
    }
    public bool ContainPos(int m, int n) {
        if (setPos[m, n] == 1) {
            return true;
        }
        return false;
    }

}
