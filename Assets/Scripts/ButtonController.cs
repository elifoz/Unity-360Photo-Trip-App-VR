using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//relevant with Photo panel not userlist panel
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
        // PhotoManagerController.Singleton.LoadPhoto(buttonData.photoId);
        //accessVariables.playerCanvasMenu.SetActive(true);
        //accessVariables.selectionCanvas.SetActive(false);
        Photon_PhotoManager.Singleton.state.PhotoId = buttonData.photoId;
        accessVariables.rawImage.SetActive(true);
        accessVariables.userListPanel.SetActive(true);
        accessVariables.photoContent.SetActive(false);

    }

  

    
}
