using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStone : MonoBehaviour
{
    public GameObject stoneW;
    public GameObject stoneB;

    bool black;
    int numStone;
    // Start is called before the first frame update
    void Start()
    {
        numStone = 0;
        black = true;
        InstantiateStone();
    }
    public void InstantiateStone() {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (black)
        {
            Instantiate(stoneB, pos, transform.rotation, transform);
            black = false;
        }
        else
        {
            Instantiate(stoneW, pos, transform.rotation, transform);
            black = true;
        }
        numStone++;
    }
}
