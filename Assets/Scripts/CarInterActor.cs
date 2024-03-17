using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarInterActor : MonoBehaviour
{

    public static CarInterActor Instance;

    private PlayerInput _playerInput;
    [SerializeField] private float interactRange;
    [SerializeField] private LayerMask itemLayer;
    [SerializeField] private GameObject camera;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private string DisplayString;
    [SerializeField] private FirstPersonController firstPersonController;


    public  bool CanRepairCar;


    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null) { Instance = this; }
        _playerInput = GetComponent<PlayerInput>();
        firstPersonController = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    public void OnInteract(InputValue value )
    {
       if (CanRepairCar)
        {
            //open inventory 
            GameManager.Instance.CheckWinCondition();
            //GetComponent<FirstPersonController>().InteractWithInventory();
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject.CompareTag("Car"))
        {
            Debug.Log(other);
            interactText.text = DisplayString;

            CanRepairCar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            interactText.text = null;
            CanRepairCar = false;
        }
    }






}
