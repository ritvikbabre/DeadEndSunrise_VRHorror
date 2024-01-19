using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Look : MonoBehaviour
{
    public Transform target;
    public float MouseSensi=100f; 
    public Transform PlayerBody;
    public bool cursorLocked=false;
    float xRotation = 0f;
    public Light flashlight;
    public bool flashOn;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cursorLocked = true;
        PlayerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        flashlight = GetComponentInChildren<Light>();
        flashlight.enabled = false;
        flashOn = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
      
            if (cursorLocked)
            { cursorLocked = false; Cursor.lockState = CursorLockMode.None; }
            else { cursorLocked = true; Cursor.lockState = CursorLockMode.Locked; }

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashOn) 
            {
                flashlight.enabled = false;
                flashOn = false;
            }
            else
            {
                flashlight.enabled=true;
                flashOn = true;
            }
        }

        float mouseX = Input.GetAxis("Mouse X") * MouseSensi * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensi * Time.deltaTime;
        xRotation-= mouseY;
        xRotation=Mathf.Clamp(xRotation, -70f, 45f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }

    private void LateUpdate()
    {
        transform.position = target.position;
    }
}
