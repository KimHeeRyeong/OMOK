using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReciveManager : MonoBehaviour
{
    bool recive = false;
    private List<string> msgs = new List<string>();
    AddStone add;
    public GameObject endPanel;
    public Text endText;
    public GameObject otherUI;
    public GameObject startUI;
    public CenterStoneColor stoneColor;
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
                otherUI.SetActive(true);
                StartCoroutine(OppenentIn(start.state));
                Debug.Log("Start!");
                break;
            case 2://play
                Play play = JsonUtility.FromJson<Play>(str);
                add.InstantiateOtherStone(play.m, play.n);
                GameSingleton.Instance.ChangeMyTurn();
                stoneColor.MyTurn();
                break;
            case 3://end
                End end = JsonUtility.FromJson<End>(str);
                if (end.winner == GameSingleton.Instance.GetStoneState())
                {
                    //끝!
                    endText.GetComponent<Text>().text = "You Win!";
                }
                else
                {
                    add.InstantiateOtherStone(end.m, end.n);
                    endText.GetComponent<Text>().text = "You Lose";
                }
                endPanel.SetActive(true);
                break;
            case 4://message
                break;
        }
    }
    IEnumerator OppenentIn(PosState st) {
        yield return new WaitForSeconds(0.5f);
        startUI.SetActive(true);
        StartCoroutine(StartGame(st));
    }
    IEnumerator StartGame(PosState st) {
        yield return new WaitForSeconds(1.0f);
        GameSingleton.Instance.SetStoneState(st);
        if(st== PosState.Black)
        {
            stoneColor.MyTurn();
        }
        else
        {
            stoneColor.OtherTurn();
        }

    }
    
}
