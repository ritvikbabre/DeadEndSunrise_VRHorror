using UnityEngine;

public class GyroToCameraRotation : MonoBehaviour
{

    private bool gyroEnabled;
    private Gyroscope gyro;

    private GameObject cameraContainer;
    private Quaternion rotFix;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform CameraSlot;

    void Start()
    {
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);
        cameraContainer.transform.position = playerTransform.position;

         Invoke("EnableGyro", .1f);
    }




     void EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rotFix = new Quaternion(0f, 0f, 1f, 0f);

            gyroEnabled = true;
        }
        else
        {
            gyroEnabled = false;
        }
    }

    void Update()
    {
        if (gyroEnabled)
        {

            transform.localRotation = gyro.attitude * rotFix;
            Quaternion yRotation = Quaternion.Euler(0, transform.rotation.y, 0);         
            playerTransform.localRotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
        }
    }

    private void FixedUpdate()
    {
        cameraContainer.transform.position = CameraSlot.position ;
    }

}
