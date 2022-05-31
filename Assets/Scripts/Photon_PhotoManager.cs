using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class Photon_PhotoManager : EntityBehaviour<IPhotoManager>
{
    public static Photon_PhotoManager Singleton;
    void Start()
    {
        state.AddCallback("PhotoId",PhotoIdChangeEvent); //when photoId changed it will be trigger
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

    void PhotoIdChangeEvent()
    {
        PhotoManagerController.Singleton.LoadPhoto(state.PhotoId);
    }

   
  
}
