using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayClick : MonoBehaviour
{
    public GameObject wait;
    public void ActiveWait() {
        wait.SetActive(true);
    }
}
