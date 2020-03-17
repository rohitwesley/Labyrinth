using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Agents
{
    public class ObjectInfo : MonoBehaviour
    {
        public ObjectType objectType = ObjectType.Floor;

    }

    public enum ObjectType
    {
        Ball,
        Floor,
        Wall,
        Hole
    }
}