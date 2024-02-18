using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemPicker : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField] private float pickUpRange;
    [SerializeField] private LayerMask itemLayer;
    [SerializeField] private GameObject camera;
    [SerializeField] private Canvas PickUpMessage;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private string DisplayString;
    [SerializeField] private bool canPickUp;


    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        PickUpMessage.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered trigger with " + other.gameObject.name);
        if (other.gameObject.CompareTag("item"))
        {
            Debug.Log(other);
            PickUpMessage.transform.position = other.transform.position + Vector3.up; // Position the canvas above the item
            PickUpMessage.enabled = true;
            interactText.text = DisplayString;

            canPickUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("item"))
        {
            PickUpMessage.enabled = false;
            interactText.text = null;
            canPickUp = false;
        }
    }

    public void OnInteract(InputValue value)
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position,camera.transform.forward, out hit,pickUpRange))
        {
            GameObject obj = hit.collider.gameObject;
            ItemPickUp itemPickUp;
            CarHandler carHandler;

            if (obj.TryGetComponent<ItemPickUp>(out itemPickUp) )
            {

                itemPickUp.PickUP();
                PickUpMessage.enabled = false;
                interactText.text = null;
            }
        }
    }
}
