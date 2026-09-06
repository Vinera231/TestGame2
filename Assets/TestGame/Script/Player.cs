using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float gravity = -30f;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _jump = 3f;
    [SerializeField] private CharacterController _controller;

    private bool _isGround;
    private float _moveX, _moveZ;
    private bool _canJump = true;

    private void Update()
    {
        _isGround = _controller.isGrounded;

        if (_isGround && _velocity.y < 0)
            _velocity.y = -2f;

        _moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * _moveZ;
        _controller.Move(_speed * Time.deltaTime * move);

        _velocity.y += gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public void Jump()
    {
        if (_isGround && _canJump)
            _velocity.y = Mathf.Sqrt(_jump * -2f * gravity);
    }
}
