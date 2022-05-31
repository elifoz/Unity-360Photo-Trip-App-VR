using UnityEngine;
using System.Collections;

public class SimplifiedNavigation : MonoBehaviour
{

    public static SimplifiedNavigation instance;

    void Awake()
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
    public GameObject h_Origin;

    private Quaternion currRotation;
    private Quaternion desiredRotation;
    private Quaternion rotation;

    float curZ = 5.0f;
    float desZ = 5.0f;

    float zoomDampening = 5.0f;
    public float yDeg;
    public float xDeg;
    public float xSpeed = 200.0f;
    public float ySpeed = 200.0f;

    public int MinY = -80;
    public int MaxY = 80;

    public static bool isDisabled = false;
    public static float disablingTimer;
    public static float disablingDelay = 3;

    public GameObject myCam;

    public static bool _IsMouseOrbitEnable = true;
    public bool limit_Pos;
    private bool _skipNext;

    private bool _freeLook = false;
    public bool _isCameraLocked = false;
    public bool _isCameraDefaultLocation = true;
    public bool Active = true;
    void Update()
    {
        if (Active == true)
        {


            if (Input.GetMouseButtonDown(0))
            {
                _freeLook = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                _freeLook = false;
            }


            if (!isDisabled)
            {



                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    _skipNext = true;
                }

                //if(Input.GetKey(KeyCode.Mouse0) && _IsMouseOrbitEnable)//orbit
                //if(Input.touchCount == 1 && _IsMouseOrbitEnable)
                if (Input.GetMouseButton(0) && _IsMouseOrbitEnable && !_isCameraLocked)
                {

                    disablingTimer = Time.time + disablingDelay;

                    if (_skipNext)
                    {
                        _skipNext = !_skipNext;
                    }
                    else
                    {
                        yDeg += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                        xDeg += Input.GetAxis("Mouse Y") * -ySpeed * 0.02f;
                    }

                    xDeg = LimitAngle(xDeg, MinY, MaxY);
                    desiredRotation = Quaternion.Euler(xDeg, yDeg, 0);

                    currRotation = h_Origin.transform.rotation;
                    rotation = Quaternion.Lerp(currRotation, desiredRotation, Time.deltaTime * zoomDampening);
                    h_Origin.transform.rotation = rotation;
                }
                else// if(desiredRotation != h_Origin.transform.rotation)
                {

                    desiredRotation = Quaternion.Euler(xDeg, yDeg, 0);

                    currRotation = h_Origin.transform.rotation;
                    rotation = Quaternion.Lerp(currRotation, desiredRotation, Time.deltaTime * zoomDampening);
                    h_Origin.transform.rotation = rotation;
                }

                if (curZ != desZ)
                {
                    transform.Translate(Vector3.forward * (desZ - curZ), myCam.transform);
                    curZ = desZ;
                    //actualPanSpeed = panSpeed * (1 + ((MaxZ-curZ))/(MaxZ));
                }



            }
        }


    }

    public void SimplifiedOn()
    {
        Active = true;
       // yDeg = 180;
        xDeg = 0;
    }
    public void SimplifiedOn_EventTrigger()
    {
        Active = true;
    
    }
    public void SimplifiedOff()
    {
        Active = false;
    }
    private static float LimitAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }

    public void RotationUpdate(float _xDeg, float _yDeg)
    {
        if (!_freeLook)
        {
            yDeg = _yDeg;
            xDeg = _xDeg;
        }

    }

    public void CameraLocker()
    {
        _isCameraLocked = !_isCameraLocked;
    }

    public void ChangeCameraPosition()
    {
        if (_isCameraDefaultLocation)
        {
            this.gameObject.transform.position = new Vector3(-3.53f, 0f, 3f) + new Vector3(0, 0f, 0);//this.gameObject.transform.position = new Vector3(-3.53f, -0.782f, 3f) + new Vector3(0, 0.70f, 0);
            _isCameraDefaultLocation = !_isCameraDefaultLocation;
        }
        else
        {
            this.gameObject.transform.position = new Vector3(-3.53f, 0f, 1.8f);// this.gameObject.transform.position = new Vector3(-3.53f, -0.26f, 1.8f);
            _isCameraDefaultLocation = !_isCameraDefaultLocation;

        }
    }
}
