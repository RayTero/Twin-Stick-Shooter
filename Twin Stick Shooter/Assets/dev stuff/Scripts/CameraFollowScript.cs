using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {
    [SerializeField]
    private GameObject Player;
    Vector3 offset;

    void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    void LateUpdate()
    {
        float newXPosition = Player.transform.position.x + offset.x;
        float newZPosition = Player.transform.position.z + offset.z;
        float newYposition  = Player.transform.position.y + offset.y;

        transform.position = new Vector3(newXPosition, newYposition, newZPosition);
    }
}
