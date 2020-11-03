using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MonoManager.Instance.On(MonoEventType.Update, Deuu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Deuu()
    {
        Debug.Log("im monster");
    }
}
