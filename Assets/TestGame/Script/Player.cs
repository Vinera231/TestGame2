using System;
using Unity.Netcode;
using UnityEngine;
using UnityInput = UnityEngine.Input;

public class Player : NetworkBehaviour
{
    [SerializeField] private float gravity = -30f;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _jump = 3f;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private AnimationPlayer _animationPlayer;
    [SerializeField] private GameOverPanel _gameOverPanel;
    [SerializeField] private FinishPanel _finishPanel;

    public event Action Died;
    public event Action Won;
    private bool _isGround;
    private float _moveZ;

    private void Update()
    {
        if (!IsOwner)
            return;

        _isGround = _controller.isGrounded;
        if (_isGround && _velocity.y < 0)
            _velocity.y = -2f;

        _moveZ = UnityInput.GetAxis("Vertical");

        if (_moveZ != 0)
            _animationPlayer.PlayWalk();
        else
            _animationPlayer.PlayIdle();

        Vector3 move = transform.forward * _moveZ;
        _controller.Move(_speed * Time.deltaTime * move);

        _velocity.y += gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);

        if (UnityInput.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (UnityInput.GetKeyDown(KeyCode.E)) 
           SendHelloServerRpc();    
    }

    public void Jump()
    {
        if (_isGround)
        {
            _velocity.y = Mathf.Sqrt(_jump * -2f * gravity);
            _animationPlayer.PlayJump();
        }
    }

    public void PlayerDied()
    {
        Died?.Invoke();
        PauseSwitcher.Instance.Pause();
        _gameOverPanel.Show();
        AfterDied();
        _animationPlayer.PlayIdle();
    }

    public void PlayerWin()
    {
        Won?.Invoke();
        PauseSwitcher.Instance.Pause();
        _finishPanel.Show();
        AfterDied();
    }

    public void AfterDied()
    {
        PauseSwitcher.Instance.Continue();
    }

    [ServerRpc]
    private void SendHelloServerRpc()
    {
        SendHelloClientRpc("Hello");
    }

    [ClientRpc]
    private void SendHelloClientRpc(string message) =>
        Debug.Log(message);
}