using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Agents
{
    public class HoleState : MonoBehaviour
    {
        [SerializeField] private Collider hole;

        //When the Primitive collides with the walls, it will reverse direction
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.GetComponent<ObjectInfo>().objectType == ObjectType.Ball)
            {
                Debug.Log("End");
                other.gameObject.SetActive(false);
            }
        }

    }
}