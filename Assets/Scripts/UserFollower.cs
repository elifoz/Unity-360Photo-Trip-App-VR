using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;
public class UserFollower : MonoBehaviour
{
    public static UserFollower instance;
    public Camera RenderCam;
    public Vector3 FirstPos;
    public Camera FollowCam;
   // public GameObject RenderTexture;
    public static BoltEntity SelectedUser;
    public GameObject CamParent;
    public static bool IsFollow = false;
    public static UserButtonController SelectedUserUIObj;
    public GameObject SelectedUserObj;

    private static UserSpawnController selectedUserController;

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
        FirstPos = RenderCam.transform.position;
    }
    public void UserSelector(BoltEntity _SelectedUser)
    {
        if (SelectedUser != null && SelectedUser.NetworkId == _SelectedUser.NetworkId)
        {
            Debug.LogError("{ Nara Debug Controller ---> Aynı User");
            Deselect();
            RenderCam.transform.position = FirstPos;
            RenderCam.transform.localEulerAngles  = Vector3.zero;
            RenderCam.gameObject.SetActive(true);
            // FollowCam.gameObject.SetActive(false);
            return;
        }

        if (SelectedUser != null)
        {
            RenderCam.transform.position = FirstPos;
            RenderCam.transform.localEulerAngles  = Vector3.zero;
            Deselect();
        }

        //UserButtonController.instance.StateImg.color = UserButtonController.instance.FollowingColor;
        SelectedUser = _SelectedUser;
        SelectedUserObj = SelectedUser.gameObject;
        //Eski hatirlamiyorum calismiyor//      selectedUserController = SelectedUser.GetComponent<UserController>();
        selectedUserController = SelectedUser.gameObject.GetComponent<UserSpawnController>();

        SelectedUserUIObj = UserManager.GetUIButton(_SelectedUser.GetState<IUser>().DeviceID);
        //SelectedUserUIObj.FollowingMe(true);
        IsFollow = true;
      //  RenderCam.gameObject.SetActive(false);
        //  FollowCam.gameObject.SetActive(true);
        //  SimplifiedNavigation.instance.SimplifiedOff();

    }

    public static void Deselect()
    {
        IsFollow = false;
        //UserButtonController.instance.StateImg.color = UserButtonController.instance.OnlineColor;
        SimplifiedNavigation.instance.SimplifiedOn();

        //SelectedUserUIObj.FollowingMe(false);
        SelectedUser = null;
        selectedUserController = null;

    }

    private void FixedUpdate()
    {
        if (SelectedUser != null)
        {
            UIF_FollowUserView();

        }

    }
    public void UIF_FollowUserView()
    {

        if (IsFollow)
        {
            Debug.LogError("RenderCam" + "+" + RenderCam + "+");
            Debug.LogError("selectedUserController" + "+" + selectedUserController + "+");
            RenderCam.transform.eulerAngles = new Vector3(selectedUserController.Head.transform.eulerAngles.x, selectedUserController.Head.transform.eulerAngles.y, selectedUserController.Head.transform.eulerAngles.z);
            selectedUserController.Head.position = PhotoManagerController.Singleton.Photo360.transform.position;
            RenderCam.transform.position = selectedUserController.Head.position;
          



        }
    }
}
