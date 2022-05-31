using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using Photon.Bolt;
using UnityEngine.UI;

public class UserSpawnController : EntityBehaviour<IUser>
{
    public static UserSpawnController ownerEntity;
    public PhotoManagerController accessVariables;


    [Header("Clients")]
    public GameObject MyOwner;
    public GameObject GuestPrefab;
    public string LobbyName;
    public int photoId;
  
    

    [Header("Host")]
    public string userName="naraa";
    public Transform Head;
    public string deviceId;
    public GameObject FakeUser;
    public Transform RHand;
    public Transform LHand;

   
   
    private void Start()
    {
        if (AppInfo.instance != null)
        {
            switch (AppInfo.instance.deviceType)
            {
                case DeviceType.Host:
                  
                    FakeUser.SetActive(true);
                    deviceId = state.DeviceID;
                    userName = state.UserName;
                 
                    state.SetTransforms(state.UserHeadset, Head);
                    state.SetTransforms(state.RightHand, RHand);
                    state.SetTransforms(state.LeftHand, LHand);
                    RHand.gameObject.SetActive(false);
                    LHand.gameObject.SetActive(false);

                    UserData FoundUser = UserManager.Users.Find(x => x.DeviceID == deviceId);
                    if (FoundUser != null)
                    {
                        FoundUser.UserUIObj.CheckState(true);
                    }
                    if (userName != null && deviceId != null)
                    {
                        UserData NewData = new UserData();
                        NewData.UserEntity = entity;
                        NewData.UserName = userName;
                        NewData.DeviceID = deviceId;
                        UserManager.Users.Add(NewData);
                        Debug.Log(userName + "USER ENTERED!");

                        UserManager.instance.UserDataController(NewData); //go and create a button for this client
                    }
                    else
                    {
                        Debug.Log("User data is NULL!");
                        StartCoroutine(CheckData());
                    }
                    break;

                case DeviceType.Client:
                    if (entity.IsOwner)

                    {
                        AppInfo.instance.keyboard.SetActive(false);
                        AppInfo.instance.clientPanel.SetActive(false);
                        PhotoManagerController.Singleton.Photo360.transform.position = UserController.instance.Head.transform.position;
                        state.UserName = AppInfo.instance.userName.text;
                        state.DeviceID = AppInfo.instance.deviceID;
                       
                        state.SetTransforms(state.UserHeadset,UserController.instance.Head.transform);
                        state.SetTransforms(state.LeftHand,UserController.instance.LHand.transform);
                        state.SetTransforms(state.RightHand, UserController.instance.RHand.transform);
                       
                    }

                    break;
                default:
                    break;
            }

        }

        IEnumerator CheckData()
        {

            while (userName == null && deviceId == null)
            {
                userName = state.UserName;
                deviceId = state.DeviceID;
                if (userName != null && deviceId != null)
                {
                    Debug.LogError("{ Nara Debug Controller ---> User datasý dolduruldu.");
                    UserData NewData = new UserData();
                    NewData.UserEntity = entity;
                    NewData.UserName = userName;
                    NewData.DeviceID = deviceId;
                    UserManager.Users.Add(NewData);
                    Debug.LogError(userName + "USER ENTERED!");
                    UserManager.instance.UserDataController(NewData);

                    UserData FoundUser = UserManager.Users.Find(x => x.DeviceID == deviceId);

                    if (FoundUser != null)
                    {
                        FoundUser.UserUIObj.CheckState(true);
                       
                    }
                    //  MyServerBuffer.instance.Buffer(DeviceID); //2021 Buffer Uyarýlacak
                    StopCoroutine("CheckData");
                }

                yield return new WaitForSeconds(0.2f);
            }
        }

    }

  
    private void SetUserForClients()
    {
        FakeUser.SetActive(false);
        if (entity.IsOwner)
        {
            ownerEntity = this;
            MyOwner = OwnerUser.instance.gameObject;
            MyOwner.transform.SetParent(transform);

            state.SetTransforms(state.UserHeadset, MyOwner.GetComponent<UserController>().Head);
            state.SetTransforms(state.RightHand, MyOwner.GetComponent<UserController>().RHand);
            state.SetTransforms(state.LeftHand, MyOwner.GetComponent<UserController>().LHand);
 
            if (OwnerUser.instance.myInputModule != null)
            {
                Debug.LogError("Input Module Null Deðil");
                OwnerUser.instance.myInputModule.GetComponent<CurvedUIInputModule>().controlMethod = OwnerUser.instance.controlMethod;
                OwnerUser.instance.myInputModule.GetComponent<CurvedUIInputModule>().UsedHand = CurvedUIInputModule.Hand.Both;
                OwnerUser.instance.myInputModule.GetComponent<CurvedUIInputModule>().RightXRController = MyOwner.GetComponent<UserController>().RHand.gameObject.GetComponent<XRController>();
                OwnerUser.instance.myInputModule.GetComponent<CurvedUIInputModule>().LeftXRController = MyOwner.GetComponent<UserController>().LHand.gameObject.GetComponent<XRController>();
            }
            else
            {

                if (OwnerUser.instance.myInputModule != null)

                    Debug.LogError("Input Module Null ");
                if (MyEventSystem.instance != null)
                {
                    Debug.LogError("MyEventSystem  Null deðil ");
                    //  OwnerUser.instance.myInputModule.GetComponent<CurvedUIInputModule>(). = MyEventSystem.instance.gameObject.GetComponent<CurvedUIInputModule>();
                    OwnerUser.instance.myInputModule.GetComponent<CurvedUIInputModule>().controlMethod = OwnerUser.instance.controlMethod;
                    OwnerUser.instance.myInputModule.GetComponent<CurvedUIInputModule>().UsedHand = CurvedUIInputModule.Hand.Both;
                    OwnerUser.instance.myInputModule.GetComponent<CurvedUIInputModule>().RightXRController = MyOwner.GetComponent<UserController>().RHand.gameObject.GetComponent<XRController>();
                    OwnerUser.instance.myInputModule.GetComponent<CurvedUIInputModule>().LeftXRController = MyOwner.GetComponent<UserController>().LHand.gameObject.GetComponent<XRController>();
                }
            }
            state.DeviceID = AppInfo.instance.deviceID;
            //state.UserName = MyOwner.GetComponent<UserController>().Name;
            //  MyBuffer.instance.CheckServerState();
        }
        else
        {
            GameObject newGuest = Instantiate(GuestPrefab, transform);
        }
    }



}
