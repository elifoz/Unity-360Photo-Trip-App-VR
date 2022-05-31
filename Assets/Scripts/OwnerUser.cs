using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CurvedUIInputModule;

public class OwnerUser : MonoBehaviour
{
    public static OwnerUser instance;
    public Vector3 FirstPos;
    public Vector3 FirstRot;
    public GameObject myInputModule;
    public CUIControlMethod controlMethod;
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
    private void Start()
    {
        FirstPos = transform.position;
        FirstRot = transform.eulerAngles;

    }
}
