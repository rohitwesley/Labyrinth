using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Agents
{

    public class ObjectControler : MonoBehaviour
    {
        [SerializeField] private KeyCode _TiltXPlusKey = KeyCode.S;
        [SerializeField] private KeyCode _TiltXMinusKey = KeyCode.W;
        [SerializeField] private KeyCode _TiltYPlusKey = KeyCode.A;
        [SerializeField] private KeyCode _TiltYMinusKey = KeyCode.D;
        [SerializeField] private float _Speed = 100.0f;
        [Range(0,90)]
        [SerializeField] private float _maxAngle = 25.0f;
        [SerializeField] private Rigidbody _objectRB;
        
        void FixedUpdate()
        {
            // rotate object when rotation key is pressed by Velocity * Direction
            float deltaSpeed;
            if(Input.GetKey(_TiltXPlusKey))
            {
                deltaSpeed = _Speed * Time.deltaTime;
                RotateObject(Vector3.left, deltaSpeed);
            }
            if(Input.GetKey(_TiltXMinusKey))
            {
                deltaSpeed = _Speed * Time.deltaTime;
                RotateObject(Vector3.right, deltaSpeed);
            }
            if(Input.GetKey(_TiltYPlusKey))
            {
                deltaSpeed = _Speed * Time.deltaTime;
                RotateObject(Vector3.forward, deltaSpeed);
            }
            if(Input.GetKey(_TiltYMinusKey))
            {
                deltaSpeed = _Speed * Time.deltaTime;
                RotateObject(Vector3.back, deltaSpeed);
            }
        }

        void RotateObject(Vector3 eulerAngleVelocity, float deltaSpeed)
        {
            // Rotate object by given velocity
            Quaternion maxRotation = Quaternion.Euler(eulerAngleVelocity * 20);
            Quaternion deltaRotation = Quaternion.RotateTowards(_objectRB.rotation, maxRotation, deltaSpeed);
            _objectRB.MoveRotation(deltaRotation);
        }

    }

}
