using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed = 6f;
    [SerializeField]
    private float _maxDistance = 1f;

    public void Move(Vector3 target)
    {
        float distance = Vector3.Distance(transform.position, target);
        if (distance < _maxDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * _movementSpeed);
        }
    }
}