using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControler : MonoBehaviour
{
    [SerializeField] private KeyCode _TiltXPlusKey = KeyCode.W;
    [SerializeField] private KeyCode _TiltXMinusKey = KeyCode.S;
    [SerializeField] private KeyCode _TiltYPlusKey = KeyCode.A;
    [SerializeField] private KeyCode _TiltYMinusKey = KeyCode.D;
    [SerializeField] private float _Speed = 100.0f;
    [SerializeField] private Rigidbody _objectRB;
    

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        // rotate object when rotation key is pressed by Velocity * Direction
        Vector3 eulerAngleVelocity;
        if(Input.GetKey(_TiltXPlusKey))
        {
            eulerAngleVelocity = Vector3.forward * _Speed * Time.deltaTime;
            RotateObject(eulerAngleVelocity);
        }
        if(Input.GetKey(_TiltXMinusKey))
        {
            eulerAngleVelocity = Vector3.back * _Speed * Time.deltaTime;
            RotateObject(eulerAngleVelocity);
        }
        if(Input.GetKey(_TiltYPlusKey))
        {
            eulerAngleVelocity = Vector3.left * _Speed * Time.deltaTime;
            RotateObject(eulerAngleVelocity);
        }
        if(Input.GetKey(_TiltYMinusKey))
        {
            eulerAngleVelocity = Vector3.right * _Speed * Time.deltaTime;
            RotateObject(eulerAngleVelocity);
        }
    }

    void RotateObject(Vector3 eulerAngleVelocity)
    {
        // Rotate object by given velocity
        
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
        _objectRB.MoveRotation(_objectRB.rotation * deltaRotation);
    }

}
