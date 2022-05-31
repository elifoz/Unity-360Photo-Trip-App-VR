using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{

    public InputField InputBox;
    public Sprite Selected;
    public Sprite Normal;
    [Header("Keyboard")]
    public Image Highlight;
    public float extra;
    [Header("Panel")]
    public Image p_Highlight;
    public float p_extra;
    public void UIF_SetSelectedInputField(InputField inputField)
    {
        /*    if (InputBox != null)
                InputBox.GetComponent<Image>().sprite = Normal;

            InputBox = inputField;
            inputField.GetComponent<Image>().sprite = Selected;*/
        //    if (InputBox != null)
        //      InputBox.GetComponent<Image>().color = new Color32(117,117,117,255);
        AppInfo.instance.keyboard.SetActive(true);
        InputBox = inputField;

        //  inputField.GetComponent<Image>().color = Color.white;

    }

    public void Input(string character)
    {
        if (InputBox == null)
            return;
        InputBox.text += character;
        if (AppInfo.instance != null)
        {
            AppInfo.instance.Vibrate();
        }

    }
    public void SetHighlight(RectTransform rectTransform)
    {
        Highlight.gameObject.SetActive(true);
        Highlight.rectTransform.localPosition = rectTransform.localPosition;
        Highlight.rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x + extra, rectTransform.sizeDelta.y + extra);

        Debug.LogError(rectTransform.sizeDelta);
        CancelInvoke();
        Invoke("HighlightCloser", 0.3f);
    }
    private void HighlightCloser()
    {
        Highlight.gameObject.SetActive(false);
    }

   /* public void SetHighlightPanel(RectTransform rectTransform)
    {
        p_Highlight.gameObject.SetActive(true);
        p_Highlight.rectTransform.position = rectTransform.position;
        p_Highlight.rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x + p_extra, rectTransform.sizeDelta.y + p_extra);

        Debug.LogError(rectTransform.sizeDelta);
        CancelInvoke();
        Invoke("HighlightCloserPanel", 0.3f);
    }
    private void HighlightCloserPanel()
    {
        p_Highlight.gameObject.SetActive(false);
    }*/
    public void Backspace()
    {
        if (InputBox.text.Length > 0)
        {
            InputBox.text = InputBox.text.Substring(0, InputBox.text.Length - 1);
        }



    }


}
