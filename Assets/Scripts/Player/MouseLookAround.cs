using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookAround : MonoBehaviour
{
    [SerializeField] private float lookSpeed;

    private Vector2 _turn;
    
    // Update is called once per frame
    void Update()
    {
        _turn.x += Input.GetAxis("Mouse X");
        _turn.y += Input.GetAxis("Mouse Y");

        transform.localRotation = Quaternion.Euler(-_turn.y, _turn.x, 0);
    }
}