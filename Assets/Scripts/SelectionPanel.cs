using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SelectionPanel : MonoBehaviour
{
    public PhotoScriptable Photo;
    public Transform contentPanel;
    public GameObject photoPrefab;

    private void Start()
    {
        foreach (var item in Photo.PhotosData)
        {

            GameObject NewButton = Instantiate(photoPrefab, contentPanel);
            NewButton.GetComponent<ButtonController>().Initialize(item);

        }
    }

}

