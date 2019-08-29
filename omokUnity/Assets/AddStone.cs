using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStone : MonoBehaviour
{
    public GameObject stone;
    // Start is called before the first frame update
    void Start()
    {
        InstantiateStone();
    }
    public void InstantiateStone() {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(stone, pos, transform.rotation,transform);
    }
    
}
