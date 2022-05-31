using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class PhotoManagerController : MonoBehaviour
{
    public static PhotoManagerController Singleton;
    public PhotoScriptable Photo;
    public GameObject Photo360;
    public Camera XrCamera;
    public GameObject playerCanvasMenu;
    public GameObject selectionCanvas;
    public Text photoName;
    public int photoId;
    public LayerMask onlyPhotoLayer;
    public LayerMask defaultLayer;
    public int counter = 0;

  //  public List<InputDevice> leftDevices = new List<InputDevice>();
  // // public List<InputDevice> rightDevices = new List<InputDevice>();

  //  public static bool leftTriggerButtonAction = false;
  ////  public static bool rightTriggerButtonAction = false;

  //  public static bool leftPrimaryAction = false;
  // // public static bool rightPrimaryAction = false;




  //  public List<UnityEngine.XR.InputDevice> leftHandedControllers = new List<UnityEngine.XR.InputDevice>();
  //  InputDeviceCharacteristics desiredCharacteristicsL = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Left | UnityEngine.XR.InputDeviceCharacteristics.Controller;




  //  //public List<UnityEngine.XR.InputDevice> rightHandedControllers = new List<UnityEngine.XR.InputDevice>();
  //  //InputDeviceCharacteristics desiredCharacteristicsR = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Right | UnityEngine.XR.InputDeviceCharacteristics.Controller;

  //  void Getdevice()
  //  {
  //      UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristicsL, leftHandedControllers);
  //      //UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristicsR, rightHandedControllers);

  //      //foreach (var device in leftHandedControllers)
  //      //{
  //      //    Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
  //      //}


  //  }


  //  //private void OnEnable()
  //  //{

  //  //    // Getdevice();
  //  //    Debug.Log(leftDevices.Count + "----" + rightDevices.Count);

  //  //}

  //  void Start()
  //  {

  //      UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristicsL, leftHandedControllers);
  //      //UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristicsR, rightHandedControllers);

  //      //foreach (var device in leftHandedControllers)
  //      //{
  //      //    Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
  //      //}
  //  }

  //  // Update is called once per frame
  //  void Update()
  //  {
  //      //if (leftHandedControllers.Count == 0 || rightHandedControllers.Count == 0)
  //          if (leftHandedControllers.Count == 0)
  //              Getdevice();

  //      leftTriggerButtonAction = false;
  //      //rightTriggerButtonAction = false;
  //      leftPrimaryAction = false;
  //      //rightPrimaryAction = false;

  //      //foreach (var device in leftHandedControllers)
  //      //{
  //      //    if (device.TryGetFeatureValue(CommonUsages.triggerButton, out leftTriggerButtonAction) && leftTriggerButtonAction)
  //      //    {
  //      //        break;
  //      //    }
  //      //}

  //      //foreach (var device in rightHandedControllers)
  //      //{
  //      //    if (device.TryGetFeatureValue(CommonUsages.triggerButton, out rightTriggerButtonAction) && rightTriggerButtonAction)
  //      //    {
  //      //        break;
  //      //    }
  //      //}
  //      foreach (var device in leftHandedControllers)
  //      {
  //          if (device.TryGetFeatureValue(CommonUsages.primaryButton, out leftPrimaryAction) && leftPrimaryAction)
  //          {
  //              Photo360.SetActive(false);
  //              playerCanvasMenu.SetActive(false);
  //              selectionCanvas.SetActive(true);
  //          }
  //      }

  //      //foreach (var device in rightHandedControllers)
  //      //{
  //      //    if (device.TryGetFeatureValue(CommonUsages.primaryButton, out rightPrimaryAction) && rightPrimaryAction)
  //      //    {
  //      //         break;
  //      //    }
  //      //}

  //      //Debug.Log("XR Left Trigger: " + leftTriggerButtonAction);
  //      //Debug.Log("XR Left Trigger: " + rightTriggerButtonAction);

  //  }
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

   
public void GoNext()
    {
        if (photoId < Photo.PhotosData.Count-1)
        {
           
            Photo360.GetComponent<Renderer>().material.mainTexture = Photo.PhotosData[photoId + 1].photoTexture;
            Photo360.transform.eulerAngles = new Vector3(0f, Photo.PhotosData[photoId + 1].photoYRotation, 0f);
            photoName.text = Photo.PhotosData[photoId + 1].photoName;
            photoId = Photo.PhotosData[photoId + 1].photoId;
           
        }
    }

    public void GoPrev()
    {
           if (photoId>0)
        {
            Photo360.GetComponent<Renderer>().material.mainTexture = Photo.PhotosData[photoId - 1].photoTexture;
            Photo360.transform.eulerAngles = new Vector3(0f, Photo.PhotosData[photoId - 1].photoYRotation, 0f);
            photoName.text = Photo.PhotosData[photoId - 1].photoName;
            photoId = Photo.PhotosData[photoId - 1].photoId;
        }
    }

    //public void BackToSelectionPanel()
    //{
    //    Photo360.SetActive(false);
    //    playerCanvasMenu.SetActive(false);
    //    selectionCanvas.SetActive(true);
    //}


    

}
