using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap_camera : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        Vector3 NewPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.position = NewPos;
    }
}
