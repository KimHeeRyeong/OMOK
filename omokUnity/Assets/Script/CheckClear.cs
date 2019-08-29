using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckClear : MonoBehaviour
{
    StonePositionSetting stonePos;
    private void Start()
    {
        stonePos = GetComponent<StonePositionSetting>();
    }
    public void CheckOMOK(PosState state, int m, int n){
        if(CheckVer(state, m, n)||CheckHor(state, m, n)
            ||CheckDiagonal1(state, m, n)||CheckDiagonal2(state, m, n))
        {
            Debug.Log("Clear!");
        }else
        {
            GetComponent<AddStone>().InstantiateStone();
        }
    }
    bool CheckVer(PosState state, int m, int n)
    {
        int omok = 1;
        //check up
        for (int i = m-1; i >= 0; i--)
        {
            if (stonePos.CheckStone(state, i, n))
            {
                omok++;
            }
            else
            {
                break;
            }
        }
        //check down
        for (int i = m+1; i < 15; i++)
        {
            if (stonePos.CheckStone(state, i, n))
            {
                omok++;
            }
            else
            {
                break;
            }
        }
        if(omok == 5)
        {
            return true;
        }
        return false;
    }
    bool CheckHor(PosState state, int m, int n) {
        int omok = 1;
        //check left
        for (int i = n-1; i >= 0; i--)
        {
            if (stonePos.CheckStone(state, m, i))
            {
                omok++;
            }
            else
            {
                break;
            }
        }
        //check right
        for (int i = n+1; i < 15; i++)
        {
            if (stonePos.CheckStone(state, m, i))
            {
                omok++;
            }
            else
            {
                break;
            }
        }
        if (omok == 5)
        {
            return true;
        }
        return false;
    }
    //   ↘:this direction
    bool CheckDiagonal1(PosState state, int m, int n) {
        int omok = 1;
        //check top left
        int j = n-1;
        for (int i = m-1; i >= 0&&j>=0; i--)
        {
            if (stonePos.CheckStone(state, i, j))
            {
                omok++;
                j--;
            }
            else
            {
                break;
            }
        }
        //check bottom right
        j = n + 1;
        for (int i = n + 1; i < 15&&j<15; i++)
        {
            if (stonePos.CheckStone(state, i, j))
            {
                omok++;
                j++;
            }
            else
            {
                break;
            }
        }
        if (omok == 5)
        {
            return true;
        }
        return false;
    }
    //  ↙ :this direction
    bool CheckDiagonal2(PosState state, int m, int n) {
        int omok = 1;
        //check top right
        int j = n + 1;
        for (int i = m - 1; i >= 0 && j < 15; i--)
        {
            if (stonePos.CheckStone(state, i, j))
            {
                omok++;
                j++;
            }
            else
            {
                break;
            }
        }
        //check bottom left
        j = n - 1;
        for (int i = n + 1; i < 15 && j >=0; i++)
        {
            if (stonePos.CheckStone(state, i, j))
            {
                omok++;
                j--;
            }
            else
            {
                break;
            }
        }
        if (omok == 5)
        {
            return true;
        }
        return false;
    }
}
