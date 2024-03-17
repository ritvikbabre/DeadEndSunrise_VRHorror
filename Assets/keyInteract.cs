using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class keyInteract : MonoBehaviour
{
    private PlayerInput _playerInput;

    public bool hasKey;
    public bool canInteractWithLock;

    public GameObject LockGO;
    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            hasKey= true;
        }
    }

    public void OnInteract(InputValue value)
    {
        InterActWithLock();
    }

    public void InterActWithLock()
    {
        if (hasKey)
        {
            LockGO.active=false;
            GameManager.Instance.lockUnlocked=true;
            Debug.Log("Unlocked lock");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "lock")
        {
            canInteractWithLock = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "lock")
        {
            canInteractWithLock = false;
        }
    }
}
