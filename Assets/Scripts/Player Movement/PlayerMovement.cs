using UnityEngine;
using Cursor = UnityEngine.Cursor;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private float _runSpeed = 10f;
    [SerializeField] private float _turnSmoothTime = 0.1f;
    [SerializeField] private Transform _camera;

    private float _resistanceSpeed;

    public float WalkSpeed
    {
        get { return _walkSpeed; }
        set { _walkSpeed = value; }
    }

    public float RunSpeed
    {
        get { return _runSpeed; }
        set { _runSpeed = value; }
    }

    private CharacterController controller;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = CalculateMoveDirection(horizontalInput, verticalInput);

        bool hasInput = moveDirection.magnitude >= 0.1f;
        if (!hasInput && Mathf.Approximately(_resistanceSpeed, 0)) return;
        float speed = hasInput ? DetermineMovementSpeed() : 0;


        var targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
        float currentVelocity = 0;
        var angle = Mathf.SmoothDampAngle(transform.rotation.eulerAngles.y, targetAngle, ref currentVelocity,
            _turnSmoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0);
        MovePlayer((transform.rotation * Vector3.forward).normalized, speed);
    }

    private Vector3 CalculateMoveDirection(float horizontalInput, float verticalInput)
    {
        // Normalize
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        return moveDirection; //transform.TransformDirection(moveDirection);
    }

    private float DetermineMovementSpeed()
    {
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float speed = isRunning ? RunSpeed : WalkSpeed;
        return speed;
    }

    private void MovePlayer(Vector3 moveDirection, float speed)
    {
        Vector3 move = (moveDirection * speed - moveDirection * _resistanceSpeed + 10 * Vector3.down) * Time.deltaTime;
        controller.Move(move);
    }

    public void SetResistanceSpeed(float resistanceSpeed)
    {
        _resistanceSpeed = resistanceSpeed;
    }
}