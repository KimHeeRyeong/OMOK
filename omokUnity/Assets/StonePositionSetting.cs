using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PosState {
    None,
    Black,
    White
}
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
            for (int i = 0; i < 15; i++)
            {
                string str = "";
                //console test
                    //for(int j = 0; j < 15; j++)
                    //{
                    //    if (pos[i, j] != PosState.None)
                    //    {
                    //        str += "<color=red>" + pos[i, j] + "</color>";
                    //    }
                    //    else
                    //    {
                    //        str += pos[i, j];
                    //    }
                    //}
                    //Debug.Log(str);
                //*console test*
            }
            return true;
        }
        else
        {
            return false;
        }
    }

}
