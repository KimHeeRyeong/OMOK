using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Net;
using WebSocketSharp.Server;
using Newtonsoft.Json;

namespace Server
{
    public class Echo : WebSocketBehavior
    {
        private static List<Echo> users = new List<Echo>();

        OmokState stage;
        PosState myState;
        protected override void OnOpen() {//this에 해당하는 유저 접속
            if (users.Count > 2)
            {
                //내보내기
            }
            else
            {
                users.Add(this);
                if (users.Count == 2)
                {
                    stage = new OmokState();
                    stage.ResetPan();
                    for (int i = 0; i < 2; i++)
                    {
                        Start start = new Start();
                        if (i == 0)
                        {
                            users[i].stage = stage;
                            myState = PosState.Black;
                        }
                        else
                        {
                            myState = PosState.White;
                        }
                        start.state = myState;
                        string str = JsonConvert.SerializeObject(start);
                        users[i].Send(str);
                    }
                }
                   
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
                            for (int i = 0; i < 2; i++)
                            {
                                if (users[i] != this)
                                {
                                    users[i].Send(e.Data);
                                }
                            }
                        }
                        else
                        {
                            End end = new End();
                            end.winner = myState;
                            end.m = play.m;
                            end.n = play.n;
                            string str = JsonConvert.SerializeObject(end);
                            for(int i = 0; i < 2; i++)
                            {
                                users[i].Send(str);
                            }
                        }
                        break;
                }
            }
        }
        protected override void OnClose(CloseEventArgs e) {//this에 해당하는 유저 나감
            lock (users)
            {
                users.Remove(this);
            }
        }
        protected override void OnError(ErrorEventArgs e) {

        }
    }
}
