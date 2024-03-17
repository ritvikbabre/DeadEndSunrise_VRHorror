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
    [SerializeField] private Canvas interactCanvas;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private string DisplayString;
    [SerializeField] private bool canPickUp;


    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        interactCanvas.enabled = false;
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
            interactCanvas.transform.position = other.transform.position + Vector3.up; // Position the canvas above the item
            interactCanvas.enabled = true;
            interactText.text = DisplayString;

            canPickUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("item"))
        {
            interactCanvas.enabled = false;
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

            if (obj.TryGetComponent<ItemPickUp>(out itemPickUp))
            {

                itemPickUp.PickUP();
                interactCanvas.enabled = false;
                interactText.text = null;
            }
            else
            {
                Debug.Log("trying to get key");
                    Debug.Log("objName: " + obj.name);
                if (obj.tag == "key")
                {
                    GameManager.Instance.HasKey = true;
                    obj.SetActive(false);
                }
            }
        }
    }
}
