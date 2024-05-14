using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private float _runSpeed = 10f;

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

        float speed = DetermineMovementSpeed();

        MovePlayer(moveDirection, speed);
    }

    private Vector3 CalculateMoveDirection(float horizontalInput, float verticalInput)
    {
        // Normalize
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        return transform.TransformDirection(moveDirection);
    }

    private float DetermineMovementSpeed()
    {
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float speed = isRunning ? RunSpeed : WalkSpeed;
        return speed;
    }

    private void MovePlayer(Vector3 moveDirection, float speed)
    {
        Vector3 move = moveDirection * speed * Time.deltaTime;
        controller.Move(move);
    }
}