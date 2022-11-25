using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    #region Settings
    [Header("Speed Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float dragSpeed;
    [SerializeField] Transform playerOrientation;

    float horizontalInput;
    float verticalInput;

    Rigidbody rb;
    Vector3 moveDirection;
    #endregion

    #region Meths
    void SetRigidbody()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    void ApplyDrag()
    {
        rb.drag = dragSpeed;
    }
    void ControllerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    void LimitVelocity()
    {
        Vector3 _vel = new Vector3(rb.velocity.x, 0, rb.velocity.y);
        if(_vel.magnitude > moveSpeed)
        {
            Vector3 _limitVel = _vel.normalized * moveSpeed;
            rb.velocity = new Vector3(_limitVel.x, rb.velocity.y, _limitVel.z);
        }
    }
    void MovePlayer()
    {
        moveDirection = playerOrientation.forward * verticalInput + playerOrientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
    }
    #endregion
    #region Meths Unity
    private void Start()
    {
        SetRigidbody();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void Update()
    {
        ApplyDrag();
        LimitVelocity();
        ControllerInput();
    }
    #endregion
}