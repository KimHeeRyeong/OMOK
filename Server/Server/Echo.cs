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

        protected override void OnOpen() {//this에 해당하는 유저 접속
            users.Add(this);
            if (users.Count == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    Start start = new Start();
                    if (i == 0)
                    {
                        start.state = PosState.Black;
                    }
                    else
                    {
                        start.state = PosState.White;
                    }
                    string str = JsonConvert.SerializeObject(start);
                    users[i].Send(str);
                }
            }
            else
            {
                //내보내기
            }
        }
        protected override void OnMessage(MessageEventArgs e) {//유저로부터 메시지를 받은 경우
            lock (users)
            {
                Code code = JsonConvert.DeserializeObject<Code>(e.Data);
                switch (code.code)
                {
                    case 2://play
                        for (int i = 0; i < 2; i++)
                        {
                            if (users[i] != this)
                            {
                                users[i].Send(e.Data);
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
