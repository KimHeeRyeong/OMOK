﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Net;
using WebSocketSharp.Server;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Server
{
    public class Echo : WebSocketBehavior
    {
        private static List<Echo> users = new List<Echo>();

        OmokState stage=null;
        PosState myState;
        Echo oppenent = null;
        bool replay = false;
        bool exit = false;
        protected override void OnOpen()
        {
            lock (users) {
                int cnt = users.Count;
                for (int i = 0; i < cnt; i++)
                {
                    if (users[i].oppenent == null)
                    {
                        users[i].oppenent = this;
                        oppenent = users[i];

                        //make stage
                        stage = new OmokState();
                        stage.ResetPan();
                        oppenent.stage = stage;

                        //setState
                        oppenent.myState = PosState.Black;
                        myState = PosState.White;
                        
                        //setting start_op
                        Start start = new Start();
                        start.state = oppenent.myState;
                        string str = JsonConvert.SerializeObject(start);
                        oppenent.Send(str);

                        //setting start_this
                        start.state = myState;
                        str = JsonConvert.SerializeObject(start);
                        Send(str);
                        break;
                    }
                }
                users.Add(this);
            }

        }
        
        protected override void OnMessage(MessageEventArgs e) {//유저로부터 메시지를 받은 경우
            lock (users)
            {
                Code code = JsonConvert.DeserializeObject<Code>(e.Data);
                switch (code.code)
                {
                    case 2://play
                        Play play= JsonConvert.DeserializeObject<Play>(e.Data);
                        if(!stage.SetStone(myState, play.m, play.n))
                        {
                           oppenent.Send(e.Data);
                        }
                        else
                        {
                            End end = new End();
                            end.winner = myState;
                            end.m = play.m;
                            end.n = play.n;
                            string str = JsonConvert.SerializeObject(end);
                            Send(str);
                            oppenent.Send(str);
                        }
                        break;
                    case 5://replay
                        replay = true;
                        if (oppenent.replay == true)
                        {
                            stage.ResetPan();
                            //setState
                            PosState save = myState;
                            myState = oppenent.myState;
                            oppenent.myState = save;

                            //setting start_op
                            Start start = new Start();
                            start.state = oppenent.myState;
                            string str = JsonConvert.SerializeObject(start);
                            oppenent.Send(str);

                            //setting start_this
                            start.state = myState;
                            str = JsonConvert.SerializeObject(start);
                            Send(str);
                            replay = false;
                            oppenent.replay = false;
                        }
                        break;
                    case 7://giveup
                        {
                            GiveUp giveUp = new GiveUp();
                            giveUp.winner = oppenent.myState;
                            string str = JsonConvert.SerializeObject(giveUp);
                            Send(str);
                            oppenent.Send(str);
                            break;
                        }
                }
            }
        }
        protected override void OnClose(CloseEventArgs e) {//this에 해당하는 유저 나감
            lock (users)
            {
                if (!exit&&oppenent != null)
                {
                    oppenent.exit = true;
                    Exit exit = new Exit();
                    string str = JsonConvert.SerializeObject(exit);
                    oppenent.Send(str);
                }
                users.Remove(this);
            }
        }
        protected override void OnError(ErrorEventArgs e) {

        }
    }
}
