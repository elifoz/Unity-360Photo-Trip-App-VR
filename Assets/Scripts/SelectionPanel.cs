using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SelectionPanel : MonoBehaviour
{
    public static SelectionPanel Singleton;
    public PhotoScriptable Photo;
    public Transform contentPanel;
    public GameObject photoPrefab;
    public Transform Target;
    public float distance;
    public GameObject mainPanel;
    public GameObject playerPanel;

    private void Start()
    {
        if(AppInfo.instance.deviceType == DeviceType.Host)
        {
            foreach (var item in Photo.PhotosData)
            {

                GameObject NewButton = Instantiate(photoPrefab, contentPanel);
                NewButton.GetComponent<ButtonController>().Initialize(item);

            }
        }
      
    }

    public void Awake()
    {
        if (Singleton != null && Singleton != this)
        {
            Destroy(Singleton);
        }
        else
        {
            Singleton = this;
        }
    }
    //void FixedUpdate()
    //{
    //    if (mainPanel.gameObject.activeInHierarchy)
    //    {
    //        distance = 0;
    //        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, Target.position.y - distance,
    //     Time.deltaTime * 10), transform.position.z);
    //    }
    //    else
    //    {
    //        distance = 0.5f;
    //        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, Target.position.y - distance,
    //  Time.deltaTime * 10), transform.position.z);
    //    }
     
    //}

}

