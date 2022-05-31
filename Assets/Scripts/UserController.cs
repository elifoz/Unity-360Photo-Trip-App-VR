using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;


public class UserController : MonoBehaviour
{
    public static UserController instance;
    public Transform Head;
    public Transform RHand;
    public Transform LHand;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);

        }
    }

        //public GameObject RHandWithNeedle;
        //public GameObject LHandWithNeedle;
        //public GameObject fadeSphere;
        // public string Name;
        //[Header("UserLogin Objects")]
        //public GameObject userPanel;
        //public GameObject DCPanel;
        //public Text Header;
        //public Text warningText;
        //public Text playerPrefsText;
        //public Text DCText;
        //public InputField userName;
        //public Button playerPrefsButton;
        //public Button loginButton;
        //[Header("Admin Objects")]
        //public GameObject adminPanel;
        //public InputField passiveUserName;
        //public InputField adminPass;
        //public Text adminWarningText;
        //[Header("Variables")]
        //public string _adminPass;
        //public string _passiveUserName;
        //private void Start()
        //{
        //    if (PlayerPrefs.HasKey("PassiveUserName"))
        //    {

        //        OpenAdminPanel("User");
        //        _passiveUserName = PlayerPrefs.GetString("PassiveUserName");
        //        playerPrefsButton.gameObject.SetActive(true);
        //        playerPrefsText.text = _passiveUserName + " olarak giriş yap.";
        //        adminPanel.SetActive(false);
        //        userPanel.SetActive(true);
        //        Header.text = "User Login";
        //        myKeyboard.InputBox = userName;

        //    }
        //    else
        //    {

        //        OpenAdminPanel("Admin");
        //        playerPrefsButton.gameObject.SetActive(false);

        //    }
        //}
        //private void Update()
        //{

        //}
        //public void UIF_Login()
        //{
        //    if (string.IsNullOrEmpty(userName.text))
        //    {
        //        warningText.text = "Kullanıcı adı boş bırakılamaz!";
        //    }
        //    else
        //    {
        //        Name = userName.text;
        //        ServerSettings.instance.SuccessfulLogin();

        //    }
        //}
        //public void UIF_LoginwithPlayerPrefs()
        //{

        //    Name = PlayerPrefs.GetString("PassiveUserName");
        //    ServerSettings.instance.SuccessfulLogin();

        //}
        //public void OpenAdminPanel(string ObjName)
        //{
        //    switch (ObjName)
        //    {
        //        case "User":
        //            userPanel.SetActive(true);
        //            adminPanel.SetActive(false);
        //            Header.text = "User Login";
        //            break;
        //        case "Admin":
        //            userPanel.SetActive(false);
        //            adminPanel.SetActive(true);
        //            myKeyboard.InputBox = passiveUserName;
        //            Header.text = "Admin Panel";
        //            break;
        //        default:
        //            break;
        //    }

        //}





        //public void UIF_OpenAdminPanel()
        //{
        //    if (userPanel.activeSelf)
        //    {
        //        userPanel.SetActive(false);
        //        adminPanel.SetActive(true);
        //        Header.text = "Admin Panel";
        //    }
        //    else
        //    {
        //        userPanel.SetActive(true);
        //        adminPanel.SetActive(false);
        //        Header.text = "User Login";
        //    }
        //}
        //public void UIF_AdminPanel()
        //{
        //    if (string.IsNullOrEmpty(passiveUserName.text) || string.IsNullOrEmpty(adminPass.text))
        //    {
        //        adminWarningText.text = "Bilgileri eksiksiz ve yanlış girmediğinizden emin olunuz.";
        //    }
        //    else
        //    {
        //        if (!string.IsNullOrEmpty(_adminPass))
        //        {

        //            if (adminPass.text == _adminPass)
        //            {

        //                PlayerPrefs.SetString("PassiveUserName", passiveUserName.text);
        //                playerPrefsButton.gameObject.SetActive(true);
        //                _passiveUserName = passiveUserName.text;
        //                playerPrefsText.text = _passiveUserName + " olarak giriş yap.";
        //                adminPanel.SetActive(false);
        //                userPanel.SetActive(true);
        //                Header.text = "User Login";

        //            }
        //        }
        //    }
        //}

        //public void HandSwitcher(myHandTypes type)
        //{
        //    switch (type)
        //    {
        //        case myHandTypes.Normal:
        //            //RHandWithNeedle.SetActive(false);
        //            //LHandWithNeedle.SetActive(false);
        //            LHand.GetComponent<XRController>().modelTransform.gameObject.SetActive(true);
        //            RHand.GetComponent<XRController>().modelTransform.gameObject.SetActive(true);
        //            break;
        //        case myHandTypes.withNeedle:
        //            //RHandWithNeedle.SetActive(true);
        //            //LHandWithNeedle.SetActive(true);
        //            LHand.GetComponent<XRController>().modelTransform.gameObject.SetActive(false);
        //            RHand.GetComponent<XRController>().modelTransform.gameObject.SetActive(false);
        //            break;
        //        default:
        //            break;
        //    }


        //}
    }

    public enum myHandTypes
{
    Normal,
    withNeedle
}