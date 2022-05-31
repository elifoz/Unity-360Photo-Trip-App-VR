using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformSycn : MonoBehaviour
{
    public Transform Target;   // Start is called before the first frame update
    public int distance;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, Target.position.y-distance, 
            Time.deltaTime * 10), transform.position.z);
    }
}
