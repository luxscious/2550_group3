// Default libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the camera
public class cameraController : MonoBehaviour {

    // Vars for player object, camera offset, smoothening value and the smooth velocity
    public GameObject player;
    private float cameraBorder, smoothValue = 0.4f;
    public float cameraBorderMin = -2f, cameraBorderMax = 20f, cameraHeight = 4.5f;
    private Vector3 cameraPosition;

    // Set to 0 initially
    private Vector3 smoothVelocity = Vector3.zero;

    private float horizontalInput;

    void Update() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate() {
        if(horizontalInput > 0) {
            cameraBorder = player.transform.position.x + 5f;
        } else if(horizontalInput < 0) {
            cameraBorder = player.transform.position.x - 5f;
        } else {
            cameraBorder = player.transform.position.x;
        }

        cameraBorder = Mathf.Clamp(cameraBorder, cameraBorderMin, cameraBorderMax);

        cameraPosition = new Vector3(cameraBorder, cameraHeight, -2f);

        transform.position = Vector3.SmoothDamp(gameObject.transform.position, cameraPosition, ref smoothVelocity, smoothValue);
    }
}