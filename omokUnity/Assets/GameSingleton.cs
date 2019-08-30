using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    WAIT,//다른 플레이어가 입장하길 기다림
    PLAY,
    END
}
public class GameSingleton : MonoBehaviour
{
    private static GameSingleton instance;
    public static GameSingleton Instance { get => instance; }

    public Clinet client;
    public AddStone addStone;
    GameState gameState = GameState.WAIT;
    PosState myState = PosState.None;
    bool myTurn = false;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public GameState GetGameState() {
        return gameState;
    }
    public void SetGameState(GameState state){
        gameState = state;
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
    public void ChangeMyTurn(bool turn) {
        myTurn = turn;
    }
    public void SendFixPos(int m, int n) {
        Play play = new Play();
        play.m = m;
        play.n = n;
        string str = JsonUtility.ToJson(play);
        client.SendMsg(str);
    }
    public void SetOtherStone(int m, int n) {
        addStone.InstantiateOtherStone(m, n);
    }
}
