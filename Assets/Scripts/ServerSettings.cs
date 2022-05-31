using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Bolt;
using UdpKit;
using Photon.Bolt.Matchmaking;
using System;
using UnityEngine.SceneManagement;


public class ServerSettings : GlobalEventListener
{
    public string lobbyName;
    public static ServerSettings instance;
  
    //public string sceneName;

    public bool IsRestart = false;

    private void Start()
    {
        // SuccessfulLogin();
            
            StartForHost();
        
    }
    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StartForClient();
        }

    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            // Destroy(this);
        }
    }


    public void SuccessfulLogin()
    {
        StartCoroutine(NetWorkController());
    }

    public void Restart()
    {
        BoltNetwork.Shutdown();
        IsRestart = true;
      
        if (AppInfo.instance.deviceType == DeviceType.Host)
        {
            StartCoroutine(NetWorkController());

            Debug.LogError("ShutDown");
        }

    }

    //public void RestartClient()
    //{
    //    if (AppInfo.instance.deviceType == DeviceType.Client)
    //    {
    //        StartCoroutine(NetWorkController());

    //        Debug.LogError("ShotDownClient");
    //    }

    //}
  
    //public void StartOperations()
    //{
    //    if (AppInfo.instance != null)
    //    {
    //        switch (AppInfo.instance.deviceType)
    //        {
    //            case DeviceType.Host:
    //                StartServer();
    //                break;
    //            case DeviceType.Client:
    //                if (BoltNetwork.IsRunning)
    //                {
    //                    BoltLauncher.Shutdown();
    //                }
    //                StartMyBoltClient();

    //                break;
    //            default:
    //                break;
    //        }

    //    }
    //}

    public void StartForClient()
    {

        if (AppInfo.instance != null && AppInfo.instance.deviceType == DeviceType.Client  )
        {
            if (BoltNetwork.IsRunning)
            {
                BoltLauncher.Shutdown(); //first shutdown and open again
            }

            if (AppInfo.instance.userName.text != "")
            {
                StartCoroutine(WaitForPhoto());
                StartMyBoltClient();
               
                //SceneManager.LoadScene(sceneName);
            }
            else
            {
                AppInfo.instance.errorText.text = "Please Fill Username!";
                StartCoroutine(Wait());
              
               
            }



        }
    }

    public void StartForHost()
    {
        if(AppInfo.instance != null && AppInfo.instance.deviceType == DeviceType.Host)
        {
            StartServer();
        }
    }


    //-------------------HOST-------------------//
    public void StartServer()
    {
        BoltLauncher.StartServer();

    }
    
    Coroutine myCoroutine;
    public override void BoltStartDone()
    {
        if (BoltNetwork.IsServer)
        {

            BoltMatchmaking.CreateSession(sessionID: lobbyName);
        }   
    }




    IEnumerator CheckPhotonObjs()
    {
        while (true)
        {
            //if (photon_bundlecontroller.instance != null)
            //{
            //    photon_bundlecontroller.instance.state.bundleurl = loadclass.instance.spawnedobjurl;
            //    ýsrestart = false;
            //    debug.logerror("sad");
            //    canvascontroller.instance.loginpanel.setactive(false);
            //    canvascontroller.instance.maincanvas.setactive(true);
            //    canvascontroller.instance.errorpanel.setactive(false);
            //    stopcoroutine(mycoroutine);
            //}
            yield return new WaitForSeconds(1f);
        }
    }
   
    public void StartMyBoltClient()

    {
        BoltLauncher.StartClient();
     

    }

    public override void SessionListUpdated(Map<Guid, UdpSession> sessionList)
    {
        foreach (var session in sessionList)
        {
            UdpSession photonSession = session.Value as UdpSession;
            if (photonSession.Source == UdpSessionSource.Photon)
            {
                BoltMatchmaking.JoinSession(photonSession);

            }
        }
    }
    public bool NetworkController = false;
    IEnumerator NetWorkController()
    {
        while (true)
        {

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                if (AppInfo.instance.deviceType == DeviceType.Client)
                {
                    AppInfo.instance.errorText.text = "Control the ConnectSSSion!";
                }
              
            }
            else
            {
                if (AppInfo.instance.deviceType == DeviceType.Client)
                {
                    StartForClient();

                    //ErrorText.text = "Connecting to Session" + "\n" + "Please Wait!";

                    StopAllCoroutines();

                }
                if (AppInfo.instance.deviceType == DeviceType.Host)
                {
                    if (IsRestart)
                    {
                        //CanvasController.instance.errorPanel.SetActive(true);
                        //CanvasController.instance.errorText.text = "Oturum yeniden baþlatýlýyor. Lütfen bekleyiniz.";

                        StartForHost();

                        StopAllCoroutines();
                    }
                }

            }
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator Wait()
    {
     
        yield return new WaitForSeconds(2);

        AppInfo.instance.errorText.text = "";
    
    }

    IEnumerator WaitForPhoto()
    {

        yield return new WaitForSeconds(1);

        AppInfo.instance.infoText.text = "Connecting...";

        yield return new WaitForSeconds(30);

        AppInfo.instance.infoText.text = "Could Not Connect! Try again!";
    }

}


