using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Bolt;

public class UserButtonController : MonoBehaviour
{
    public BoltEntity Entity;
    public string DeviceID;
    public bool IsOnline = false;
    //public Image StateImg;
    //public Image followStatus;
    //public Image DownloadStatus;
    //public Image sceneStatus;
    //public Sprite inLobby, outLobby;
    //  public Image Border;
    public Text UserName;
    public Color OnlineColor;
    public Color OfflineColor;
    public Color BorderColor;
    //public void Initialized(string _DeviceID, BoltEntity _Entity, string _UserName) // Todoo
    public void Initialized(UserData userData) // Todoo
    {
        Entity = userData.UserEntity;
        DeviceID = userData.DeviceID;
        UserName.text = userData.UserName;

    }

    public void CheckState(bool IsOnline)
    {
        if (IsOnline == true)
        {
            //StateImg.color = OnlineColor;
            IsOnline = true;
        }
        else
        {
            //StateImg.color = OfflineColor;
            //DownloadStatus.gameObject.SetActive(false);
            IsOnline = false;
        }
    }
    //public void FollowingMe(bool state)
    //{
    //    if (state == true)
    //    {
    //        followStatus.gameObject.SetActive(true);
    //    }
    //    else
    //    {

    //        followStatus.gameObject.SetActive(false);
    //    }
    //}
    public void FollowUser()
    {
        if (Entity != null)
            UserFollower.instance.UserSelector(Entity);
    }


}
