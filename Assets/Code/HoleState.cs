using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleState : MonoBehaviour
{
    [SerializeField] private Collider hole;

    //When the Primitive collides with the walls, it will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<ObjectControler>() != null)
        other.gameObject.SetActive(false);
    }

}
