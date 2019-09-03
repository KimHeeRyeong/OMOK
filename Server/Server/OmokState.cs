
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class OmokState
    {
        private PosState[,] pan = new PosState[15, 15];
        public void ResetPan() {
            for (int m = 0; m < 15; m++)
            {
                for(int n = 0; n < 15; n++)
                {
                    pan[m, n] = PosState.None;
                }
            }
        }
        public bool SetStone(PosState state, int m, int n) {
            pan[m, n] = state;
            return CheckOMOK(state, m, n);
        }
        private bool CheckOMOK(PosState state, int m, int n)
        {
            if (CheckVer(state, m, n) || CheckHor(state, m, n)
                || CheckDiagonal1(state, m, n) || CheckDiagonal2(state, m, n))
            {
                return true;
            }
            return false;
        }
        bool CheckVer(PosState state, int m, int n)
        {
            int omok = 1;
            //check up
            for (int i = m - 1; i >= 0; i--)
            {
                if (pan[i, n]==state)
                {
                    omok++;
                }
                else
                {
                    break;
                }
            }
            //check down
            for (int i = m + 1; i < 15; i++)
            {
                if (pan[i, n] == state)
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
        bool CheckHor(PosState state, int m, int n)
        {
            int omok = 1;
            //check left
            for (int i = n - 1; i >= 0; i--)
            {
                if (pan[m, i] == state)
                {
                    omok++;
                }
                else
                {
                    break;
                }
            }
            //check right
            for (int i = n + 1; i < 15; i++)
            {
                if (pan[m, i] == state)
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
        bool CheckDiagonal1(PosState state, int m, int n)
        {
            int omok = 1;
            //check top left
            int j = n - 1;
            for (int i = m - 1; i >= 0 && j >= 0; i--)
            {
                if (pan[i, j] == state)
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
            for (int i = m + 1; i < 15 && j < 15; i++)
            {
                if (pan[i, j] == state)
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
        bool CheckDiagonal2(PosState state, int m, int n)
        {
            int omok = 1;
            //check top right
            int j = n + 1;
            for (int i = m - 1; i >= 0 && j < 15; i--)
            {
                if (pan[i, j] == state)
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
            for (int i = m + 1; i < 15 && j >= 0; i++)
            {
                if (pan[i, j] == state)
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
        //void DebugStones() {
        //    for(int i = 0; i < 15; i++)
        //    {
        //        for(int j = 0; j < 15; j++)
        //        {
        //            Debug.Write(pan[i, j]);
        //        }
        //        Debug.WriteLine("");
        //    }
        //}
    }
}
