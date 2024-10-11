using UnityEngine;
using Zenject;
using Animations;
using Components;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float rotationSpeed = 10f;

    private CharacterController controller;
    private MovementAnimatorController _movementAnimatorController;
    private AttackComponent _attackComponent;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;


    [Inject]
    public void Construct(CharacterController controller, MovementAnimatorController movementAnimatorController, AttackComponent attackComponent)
    {
        this.controller = controller;
        this._movementAnimatorController = movementAnimatorController;
        this._attackComponent = attackComponent;
    }

    void Start()
    {
        controller = controller ?? GetComponent<CharacterController>();
        _movementAnimatorController = _movementAnimatorController ?? GetComponent<MovementAnimatorController>();
        _attackComponent = _attackComponent ?? GetComponent<AttackComponent>();  // Проверяем, что _attackComponent получен
    }

    void Update()
    {
        // Проверка, идет ли удар
        
            HandleMovementAndJumping();  // Движение разрешено
        if (_attackComponent.IsPunching())
        {
            _movementAnimatorController.SetSpeed(0f);
            // Оставляем только анимационную логику удара
            Debug.Log("Удар выполняется");
        }

    }

    void HandleMovementAndJumping()
    {
        groundedPlayer = IsGrounded();

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Движение персонажа
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        if (move.magnitude >= 0.1f)
        {
            Debug.Log($"Player moving with speed: {currentSpeed}");
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            controller.Move(moveDirection * currentSpeed * Time.deltaTime);
            _movementAnimatorController.SetSpeed(currentSpeed / runSpeed);  // Обновляем скорость в анимации через контроллер
        }
        else
        {
            Debug.Log("Player stopped moving");
            _movementAnimatorController.SetSpeed(0f);  // Останавливаем анимацию движения
        }

        // Обработка прыжка
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            Debug.Log("Player jumped");
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
            _movementAnimatorController.SetJumping(true);  // Включаем анимацию прыжка через контроллер
        }
        else if (groundedPlayer)
        {
            _movementAnimatorController.SetJumping(false);  // Останавливаем анимацию прыжка
        }

        // Применение гравитации
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    // Метод для проверки нахождения на земле
    private bool IsGrounded()
    {
        float rayLength = 0.2f;
        Vector3 rayOrigin = transform.position + Vector3.up * 0.1f;
        return Physics.Raycast(rayOrigin, Vector3.down, rayLength);
    }
}
