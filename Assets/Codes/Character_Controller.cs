using System;
using UnityEngine;
using UnityEngine.InputSystem;

// Description:
// To control the character
// It is attached to the player character's GameObject
// and uses the Unity's CharacterController component
// to handle the character's movement, rotation, and gravity.

// Variables:
// - _input: a Vector2 variable that stores the input from the player.
// - _characterController: a CharacterController variable that stores the CharacterController component.
// - _direction: a Vector3 variable that stores the direction of the character.
// - speed: a float variable that stores the speed of the character.
// - smoothTime: a float variable that stores the smooth time of the character's rotation.
// - _currentVelocity: a float variable that stores the current velocity of the character's rotation.
// - _gravity: a float variable that stores the gravity of the character.
// - gravityMultiplier: a float variable that stores the gravity multiplier of the character.
// - _velocity: a float variable that stores the velocity of the character.

[RequireComponent(typeof(CharacterController))]
public class Character_Controller : MonoBehaviour
{
    #region Variables: Movement

    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;

    [SerializeField] private float speed;

    #endregion
    #region Variables: Rotation

    [SerializeField] private float smoothTime = 0.05f;
    private float _currentVelocity;

    #endregion
    #region Variables: Gravity

    private float _gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float _velocity;

    #endregion

    // The Awake() method is used to get the CharacterController component from the GameObject. 
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // The Update() method is used to apply gravity, rotation, and movement to the character.
    private void Update()
    {
        ApplyGravity();
        ApplyRotation();
        ApplyMovement();
    }

    private void ApplyGravity()
    {
        if (_characterController.isGrounded && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime;
        }

        _direction.y = _velocity;
    }

    private void ApplyRotation()
    {
        if (_input.sqrMagnitude == 0) return;

        var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
    }

    private void ApplyMovement()
    {
        _characterController.Move(_direction * speed * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);
    }
}
