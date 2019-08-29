﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class Clinet : MonoBehaviour
{
    ReciveManager reciveManager;
    const int PORT = 15555;
    private WebSocket socketClient;
    private void Awake()
    {
        reciveManager = GetComponent<ReciveManager>();

        socketClient = new WebSocket("ws://localhost:"+PORT+"/Echo");
        socketClient.OnOpen += OnOpen;
        socketClient.OnError += OnError ;
        socketClient.OnClose += OnClose;
        socketClient.OnMessage += OnMessage;
        socketClient.Connect();
    }
    public void OnOpen(object sender, EventArgs e){
        reciveManager.AddMsg("서버와 연결");
    }
    public void OnMessage(object sender, MessageEventArgs e)// 서버에게 메시지 받은 경우
    {
        reciveManager.AddMsg(e.Data);
    }
    public void OnClose(object sender, CloseEventArgs e) {
        reciveManager.AddMsg("서버와 연결 종료");
    }
    public void OnError(object sender, ErrorEventArgs e) {
    }
    public void SendMsg(string msg) {
        socketClient.Send(msg);
    }
}
