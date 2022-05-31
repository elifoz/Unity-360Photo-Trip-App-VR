using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class NetworkCallbacksClient : GlobalEventListener
{
    public BoltEntity User;
    public Vector3 userPos;

   
    public override void Connected(BoltConnection connection) //this func belong to Bolt library 
    {
      
            User = BoltNetwork.Instantiate(BoltPrefabs.UserSpawnController, userPos, Quaternion.identity);
        
    }

}

