using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private Transform _startPoint;

    [SerializeField] private Animator _animator;
    [SerializeField] private AudioManager audioManager;

    private float _currentSpeed;

    private Rigidbody2D _rb;

    private Vector2 _moveInput;

    private void Awake()
    {
        if (_rb == null)
            _rb = GetComponent<Rigidbody2D>();
        transform.position = _startPoint.position;
    }

    private void Start()
    {
        _currentSpeed = playerSO.WalkSpeed;
    }

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();

        if (!Mouse.current.leftButton.isPressed)
        {
            RotateToMovement();
        }
    }

    private void Update()
    {
        FlipToMouse();
        UpdateAnimations();
        bool isMoving = _moveInput.sqrMagnitude > 0.01f;
        audioManager.SetWalking(isMoving);
    }

    private void FlipToMouse()
    {
        Vector3 mouseScreen = Mouse.current.position.ReadValue();
        mouseScreen.z = Mathf.Abs(Camera.main.transform.position.z);

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);

        Vector2 direction = mouseWorld - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void UpdateAnimations()
    {
        float speed = _moveInput.magnitude;
        _animator.SetFloat("Speed", speed);
    }

    private void Move()
    {
        Vector2 move = _moveInput * _currentSpeed;
        _rb.MovePosition(_rb.position + move * Time.fixedDeltaTime);
    }

    private void RotateToMovement()
    {
        if (_moveInput.magnitude > 0.1f)
        {
            float angle = Mathf.Atan2(_moveInput.y, _moveInput.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10f * Time.fixedDeltaTime);
        }
    }

    private void RotateToMouse()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            // Площина на рівні персонажа (Z = позиція гравця)
            Plane plane = new Plane(Vector3.forward, transform.position);

            if (plane.Raycast(ray, out float distance))
            {
                Vector3 mouseWorldPos = ray.GetPoint(distance);

                Vector3 direction = mouseWorldPos - transform.position;
                direction.z = 0f;

                if (direction.sqrMagnitude > 0.01f)
                {
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

                    transform.rotation = Quaternion.Lerp(
                        transform.rotation,
                        targetRotation,
                        15f * Time.deltaTime
                    );
                }
            }
        }
    }
}