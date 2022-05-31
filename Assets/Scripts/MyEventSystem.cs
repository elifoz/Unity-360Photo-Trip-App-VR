using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEventSystem : MonoBehaviour
{
    public static MyEventSystem instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
