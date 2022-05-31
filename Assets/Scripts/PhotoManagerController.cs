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
    public bool _IsClickable = true;
    public GameObject rawImage;
    public GameObject userListPanel;
    public GameObject photoContent;
   

    public List<InputDevice> leftDevices = new List<InputDevice>();
    public List<InputDevice> rightDevices = new List<InputDevice>();


    public static bool leftPrimaryAction = false;
    public static bool rightPrimaryAction = false;
    public static bool rightSecondaryAction = false;

    public List<UnityEngine.XR.InputDevice> leftHandedControllers = new List<UnityEngine.XR.InputDevice>();
    InputDeviceCharacteristics desiredCharacteristicsL = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Left | UnityEngine.XR.InputDeviceCharacteristics.Controller;

    public List<UnityEngine.XR.InputDevice> rightHandedControllers = new List<UnityEngine.XR.InputDevice>();
    InputDeviceCharacteristics desiredCharacteristicsR = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Right | UnityEngine.XR.InputDeviceCharacteristics.Controller;

    void Getdevice()
    {
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristicsL, leftHandedControllers);
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristicsR, rightHandedControllers);
    }
    public void IsClickable()
    {
        if (_IsClickable == false)
        {
            _IsClickable = true;
        }
        else
        {
            _IsClickable = false;
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
    void Start()
    {
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristicsL, leftHandedControllers);
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristicsR, rightHandedControllers);
    }

    void Update()
    {
        if (leftHandedControllers.Count == 0 || rightHandedControllers.Count == 0)
            Getdevice();

        leftPrimaryAction = false;
        rightPrimaryAction = false;
        rightSecondaryAction = false;

        foreach (var device in leftHandedControllers)
        {
            if (device.TryGetFeatureValue(CommonUsages.primaryButton, out leftPrimaryAction) && leftPrimaryAction)
            {
                Photo360.SetActive(false);
                playerCanvasMenu.SetActive(false);
                selectionCanvas.SetActive(true);
            }
        }

        foreach (var device in rightHandedControllers)
        {
            if (photoId > 0)
            {
                if (device.TryGetFeatureValue(CommonUsages.primaryButton, out rightPrimaryAction) && rightPrimaryAction)
                {

                    if (_IsClickable == true)
                    {
                        _IsClickable = false;
                        CancelInvoke();
                        Invoke("IsClickable", 1f);
                        Photo360.GetComponent<Renderer>().material.mainTexture = Photo.PhotosData[photoId - 1].photoTexture;
                        Photo360.transform.eulerAngles = new Vector3(0f, Photo.PhotosData[photoId - 1].photoYRotation, 0f);
                        photoName.text = Photo.PhotosData[photoId - 1].photoName;
                        photoId = Photo.PhotosData[photoId - 1].photoId;
                    }

                }
            }
            if (photoId < Photo.PhotosData.Count - 1)
            {
                if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out rightSecondaryAction) && rightSecondaryAction)
                {
                    if (_IsClickable == true)
                    {
                        _IsClickable = false;
                        CancelInvoke();
                        Invoke("IsClickable", 1f);
                        Photo360.GetComponent<Renderer>().material.mainTexture = Photo.PhotosData[photoId + 1].photoTexture;
                        Photo360.transform.eulerAngles = new Vector3(0f, Photo.PhotosData[photoId + 1].photoYRotation, 0f);
                        photoName.text = Photo.PhotosData[photoId + 1].photoName;
                        photoId = Photo.PhotosData[photoId + 1].photoId;
                    }
                }

            }
        }
    }

    public void LoadPhoto(int targetIndex)
    {
        XrCamera.cullingMask = onlyPhotoLayer;
        Photo360.GetComponent<Renderer>().material.mainTexture = Photo.PhotosData[targetIndex].photoTexture;
        Photo360.transform.eulerAngles = new Vector3(0f, Photo.PhotosData[targetIndex].photoYRotation, 0f);
        photoName.text = Photo.PhotosData[targetIndex].photoName;
        Photo360.SetActive(true);
    }

    public void GoPhotoPanel()
    {
        rawImage.SetActive(false);
        userListPanel.SetActive(true);
        photoContent.SetActive(true);
    }


}



