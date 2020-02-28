using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDirection : MonoBehaviour
{
    private Transform _activeCamera;
    [SerializeField] private PlayerMovement playerMovement;
    public Vector3 _right, _forward;

    private void Awake()
    {
        playerMovement.OnPlayerMove += SubPlayerMove;
        _activeCamera = transform;
    }

    private void SubPlayerMove()
    {
        _right = _activeCamera.right.normalized;
        _forward = _activeCamera.forward.normalized;
        _right.y = 0;
        _forward.y = 0;

    }

    private void OnDisable()
    {
        playerMovement.OnPlayerMove -= SubPlayerMove;
    }
}
