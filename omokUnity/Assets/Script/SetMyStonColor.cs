using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMyStonColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameSingleton.Instance.GetStoneState() == PosState.Black)
        {
            GetComponent<SpriteRenderer>().color = Color.black;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
