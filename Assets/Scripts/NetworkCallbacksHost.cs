using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class NetworkCallbacksHost : GlobalEventListener
{
    public BoltEntity PhotoController;
    public override void BoltStartDone()
    {
        base.BoltStartDone();//otomatically 
        PhotoController = BoltNetwork.Instantiate(BoltPrefabs.Photon_PhotManager);
    }
}
