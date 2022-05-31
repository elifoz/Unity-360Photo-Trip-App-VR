using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Image thumbnail;
    public Text buttonName;
    public Photos buttonData;
    public  PhotoManagerController accessVariables;


    public void FixedUpdate()
    {
        accessVariables.Photo360.transform.position = accessVariables.XrCamera.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadContent();
        }
    }

    public void Initialize(Photos photo)
    {
        accessVariables = PhotoManagerController.Singleton;

        buttonData = photo;
        thumbnail.sprite = buttonData.photoSprite;
        buttonName.text = buttonData.photoName;
    }

    public void LoadContent()
    {
        Debug.LogError("test");
        accessVariables.XrCamera.cullingMask = accessVariables.onlyPhotoLayer;
        accessVariables.Photo360.GetComponent<Renderer>().material.mainTexture = buttonData.photoTexture;
        accessVariables.Photo360.transform.eulerAngles = new Vector3(0f, buttonData.photoYRotation, 0f);
        accessVariables.photoName.text = buttonData.photoName;
        accessVariables.photoId = buttonData.photoId;
        accessVariables.Photo360.SetActive(true);
        accessVariables.playerCanvasMenu.SetActive(true);
        accessVariables.selectionCanvas.SetActive(false);
    }

  

    
}
