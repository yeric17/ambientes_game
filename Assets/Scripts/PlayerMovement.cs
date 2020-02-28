using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour, IMove
{
    [SerializeField] private CameraDirection cameraDirection;
    [SerializeField] private PlayerInputControler _playerInput;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _walkMaxSpeed = 3f;
    [SerializeField] private float _sprintMaxSpeed = 10f;
    private float _maxSpeed = 10f;
    private Rigidbody _rigidBody;
    private Vector3 _forward;
    private int _hashSpeed;
    private float _speed = 0;


    public event Action OnPlayerMove;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _hashSpeed = Animator.StringToHash("PlayerSpeed_Vertical");
        _maxSpeed = _walkMaxSpeed;
    }

    private void Update()
    {
        
        
        if (_playerInput.AxisPressed)
        {
            _speed += 6f * Time.deltaTime;
            
            if (_playerInput.Sprint)
            {
                _maxSpeed = _sprintMaxSpeed;
            }
            else _maxSpeed = _walkMaxSpeed;

            _speed = Mathf.Clamp(_speed, 2f, _maxSpeed);

            OnPlayerMove?.Invoke();
        }
        else _speed = 0;
        
        _animator.SetFloat(_hashSpeed, _speed);

        Move(Direction * (Time.deltaTime * _speed));
        
    }
    

    public void Move(Vector3 dir)
    {
        var moveDir = dir.x * cameraDirection._right + dir.z * cameraDirection._forward;
        transform.LookAt(transform.position + moveDir); 
        _rigidBody.position += moveDir;
    }

    public Vector3 Direction
    {
        get
        {
            var dir = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")),1f);
            return dir;
        }
    }

    private bool Stopped => Direction == Vector3.zero;
}
