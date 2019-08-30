using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReciveManager : MonoBehaviour
{
    bool recive = false;
    private List<string> msgs = new List<string>();
    AddStone add;

    private void Start()
    {
        add = GetComponent<AddStone>();
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
                    DeserializeJson(save[i]);
                }
            }
        }
    }
    void DeserializeJson(string str) {
        Code code = JsonUtility.FromJson<Code>(str);
        switch (code.code) {
            case 1://start
                Start start = JsonUtility.FromJson<Start>(str);
                GameSingleton.Instance.SetStoneState(start.state);
                Debug.Log("Start!");
                break;
            case 2://play
                Play play = JsonUtility.FromJson<Play>(str);
                add.InstantiateOtherStone(play.m, play.n);
                GameSingleton.Instance.ChangeMyTurn();
                break;
            case 3://end
                break;
            case 4://message
                break;
        }
    }
}
