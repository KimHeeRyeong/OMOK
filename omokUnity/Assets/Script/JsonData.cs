using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PosState
{
    None,
    Black,
    White
}
[Serializable]
public class Code {
    public int code;

    public Code(int codeVal = 0) {
        code = codeVal;
    }
}
[Serializable]
public class Start : Code {
    public PosState state;
    public Start() : base(1) {}
}
[Serializable]
public class Play : Code {
    public int m;
    public int n;
    public Play() : base(2) {}
}
[Serializable]
public class End : Code
{
    public PosState winner;
    public int m;
    public int n;
    public End() : base(3) {}
}
[Serializable]
public class Message : Code {
    public string msg;
    public Message() : base(4) {}
}
[Serializable]
public class Replay : Code
{
    public Replay() : base(5) { }
}
[Serializable]
public class Exit : Code
{
    public Exit() : base(6) { }
}
[Serializable]
public class GiveUp : Code
{
    public PosState winner;
    public GiveUp() : base(7) { }
}
