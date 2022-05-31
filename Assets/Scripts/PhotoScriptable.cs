using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PhotoData", menuName = "360Photo/PhotoSlider", order = 1)]
public class PhotoScriptable : ScriptableObject
{
    public List<Photos> PhotosData = new List<Photos>();
}

[System.Serializable]
public class Photos
{
    public int photoId;
    public Texture photoTexture;
    public string photoName;
    public Sprite photoSprite;
    public float photoYRotation;

}