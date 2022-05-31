using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class UserManager : MonoBehaviour
{
    public static UserManager instance;
    public GameObject UserButton;
    //public GameObject notificationPanel;
    public Transform UserListPanel;
   // public Transform notificationTransform;
    public float RowSize = 103f;

    [SerializeField]
    public static List<UserData> Users = new List<UserData>();
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

    private void Update()
    {
        #region Login&Disconnect Debug
        /*   if (Input.GetKeyDown(KeyCode.L))
            {
                GameObject newNotification = Instantiate(notificationPanel, notificationTransform);
                newNotification.GetComponent<NotificationController>().Initialize("Deneme1", stateType.Login);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                GameObject newNotification = Instantiate(notificationPanel, notificationTransform);
                newNotification.GetComponent<NotificationController>().Initialize("Deneme2", stateType.Disconnect);
            }*/
        #endregion
    }
    public void UserDataController(UserData userData)
    {

        UserData FindedUser = Users.Find(x => x.DeviceID == userData.DeviceID);

        if (FindedUser.UserUIObj == null)
        {


            GameObject NewUserButton = Instantiate(UserButton, UserListPanel);

            UserListPanel.GetComponent<RectTransform>().sizeDelta += new Vector2(0f, RowSize);
            NewUserButton.transform.SetParent(UserListPanel);
            NewUserButton.GetComponent<UserButtonController>().Initialized(userData);
            NewUserButton.GetComponent<UserButtonController>().CheckState(true);
            userData.UserUIObj = NewUserButton.GetComponent<UserButtonController>();


        }
        else
        {

            FindedUser.UserEntity = userData.UserEntity;
            FindedUser.UserName = userData.UserName;
            FindedUser.UserUIObj.GetComponent<UserButtonController>().Initialized(userData);
            FindedUser.UserUIObj.GetComponent<UserButtonController>().CheckState(true);
            FindedUser.DeviceID = userData.DeviceID;
        }

        //GameObject newNotification = Instantiate(notificationPanel, notificationTransform);
      //  newNotification.GetComponent<NotificationController>().Initialize(userData.UserName, stateType.Login);
    }

    public static UserButtonController GetUIButton(string _deviceID)
    {
        return Users.Find(x => x.DeviceID == _deviceID).UserUIObj;
    }
    public static string GetUserName(string _deviceID)
    {
        return Users.Find(x => x.DeviceID == _deviceID).UserName;
    }
    public void DisconnectedUser(string UserName)
    {
       // GameObject newNotification = Instantiate(notificationPanel, notificationTransform);
       // newNotification.GetComponent<NotificationController>().Initialize(UserName, stateType.Disconnect);
    }




}

[System.Serializable]
public class UserData
{
    public string DeviceID;
    public BoltEntity UserEntity;
    public UserButtonController UserUIObj;
    public string UserName;


}


