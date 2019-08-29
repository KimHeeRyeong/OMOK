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
    public class Code
    {
        public int code;
        public Code(int codeVal = 0)
        {
            code = codeVal;
        }
    }
    public class Test : Code
    {
        public int val;
        public Test() : base(1) { }
    }

    public class Echo : WebSocketBehavior
    {
       private static List<Echo> users = new List<Echo>();

        protected override void OnOpen() {//this에 해당하는 유저 접속
            users.Add(this);
        }
        protected override void OnMessage(MessageEventArgs e) {//유저로부터 메시지를 받은 경우
            string str = e.Data;
            
            Code code = JsonConvert.DeserializeObject<Test>(e.Data);
            switch (code.code)
            {
                case 0:
                    break;
                case 1:
                    Test ts = JsonConvert.DeserializeObject<Test>(e.Data);
                    str = ts.val.ToString();
                    break;
            }
            lock (users)
            {
                int userCnt = users.Count;
                for(int i = 0; i < userCnt; i++)
                {
                    users[i].Send("Server->"+str);
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
