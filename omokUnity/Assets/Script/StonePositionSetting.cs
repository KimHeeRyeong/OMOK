using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StonePositionSetting : MonoBehaviour
{
    PosState[,] pos = new PosState[15,15];

    private void Awake()
    {
        //initialize pos state
        for(int m = 0; m < 15; m++)
        {
            for(int n = 0; n < 15; n++)
            {
                pos[m, n] = PosState.None;
            }
        }

    }
    public bool SetStone(PosState state, int m, int n) {
        if (pos[m, n] == PosState.None)
        {
            pos[m, n] = state;
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckStone(PosState state, int m, int n) {
        if (pos[m, n] == state)
        {
            return true;
        }
        else {
            return false;
        }
    }
}
