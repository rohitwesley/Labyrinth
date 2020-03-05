using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    [SerializeField] private ObjectType _objectType = ObjectType.Floor;

    enum ObjectType
    {
        Ball,
        Floor,
        Wall,
        Hole
    }
}
