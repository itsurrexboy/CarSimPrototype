using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 camOffset = new Vector3(0,5,-7);
    
    void LateUpdate()
    {
        transform.position = player.transform.position + camOffset;
        // transform.rotation = player.transform.rotation;   
    }
}
