﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReciveManager : MonoBehaviour
{
    Clinet client;
    bool recive = false;
    private List<string> msgs = new List<string>();

    bool gameStart;
    PosState myState;
    // Start is called before the first frame update
    void Awake()
    {
        client = GetComponent<Clinet>();
    }
    private void Start()
    {
    }
    public void AddMsg(string msg) {
        lock (msgs)
        {
            msgs.Add(msg);
            if (!recive)
            {
                recive = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (recive)
        {
            recive = false;
            List<string> save = null;
            lock (msgs)
            {
                save = new List<string>(msgs);
                msgs.Clear();
            }
            if (save != null)
            {
                int cnt = save.Count;
                for(int i = 0; i < cnt; i++)
                {
                    Debug.Log(save[i]);
                }
            }
        }
    }
    void DeserializeJson(string str) {
        Code code = JsonUtility.FromJson<Code>(str);
        switch (code.code) {
            case 1://start
                Start start = JsonUtility.FromJson<Start>(str);
                myState = start.state;
                gameStart = true;
                break;
            case 2://play
                break;
            case 3://end
                break;
            case 4://message
                break;
        }
    }
    public bool GameIsStart() {
        return gameStart;
    }
    public PosState GetStoneColor() {
        return myState;
    }
}
