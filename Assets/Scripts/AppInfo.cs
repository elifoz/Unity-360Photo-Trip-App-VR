using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class AppInfo : MonoBehaviour
{
    public static AppInfo instance;
    public DeviceType deviceType;
    public string deviceID;
    public XRController Right, Left;

    public Button sessionButton;
    public GameObject userListPanel;
    public Text userName;
    public GameObject UserName;
    public Text errorText;
    public Text infoText;
    public GameObject keyboard;
    public GameObject clientPanel;

    //public XRController Right, Left;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);

        }



        if (deviceType == DeviceType.Client)
        {
            XRSettings.eyeTextureResolutionScale = 4f;
           
        }

        deviceID = SystemInfo.deviceUniqueIdentifier.ToString();
    }



    public void Vibrate()
    {
        Right.SendHapticImpulse(0.4f, 0.2f);
        Left.SendHapticImpulse(0.4f, 0.2f);
    }
}

public enum DeviceType
{
    Host,
    Client
}


