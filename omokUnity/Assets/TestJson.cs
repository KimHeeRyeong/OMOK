using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Code {
    public int code;
    public Code(int codeVal = 0) {
        code = codeVal;
    }
}
[Serializable]
public class Test : Code {
    public int val;
    public Test():base(1) {}
}
public class TestJson : MonoBehaviour
{
    // Start is called before the first frame update
    Clinet cnt;
    private void Awake()
    {
        cnt = GetComponent<Clinet>();
    }
    void Start()
    {
        Test ts = new Test();
        ts.val = 10;
        string json = JsonUtility.ToJson(ts);
        cnt.SendMsg(json);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
