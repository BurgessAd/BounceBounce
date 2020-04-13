using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public Camera  camera;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        camera.transform.position = player.transform.position-10*Vector3.ProjectOnPlane(player.transform.forward, player.gravDir).normalized -  player.gravDir*3;
        camera.transform.rotation = Quaternion.LookRotation(player.transform.position - camera.transform.position, -player.gravDir);
    }
}
