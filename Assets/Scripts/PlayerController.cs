using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class PlayerController : MonoBehaviour
{
    private float _currentSpeed;
    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private float _sprintSpeed = 10f;
    private CharacterController _characterController;
    private Vector2 _moveInput;
    private Vector3 _velocity;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _currentSpeed = _walkSpeed;
    }
    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    public void OnSprint(InputValue value)
    {
        if (value.Get<float>() > 0.5f)
        {
            _currentSpeed = _sprintSpeed;
        }
        else
        {
            _currentSpeed = _walkSpeed;
        }
    }

    private void Update()
    {
        Vector2 move = new Vector2(_moveInput.x, _moveInput.y);
        _characterController.Move(move * _currentSpeed * Time.deltaTime);

    }

}