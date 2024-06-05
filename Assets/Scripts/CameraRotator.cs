using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float speed;


private void FixedUpdate() {
        transform.Rotate(0.0f,Input.GetAxis("Horizontal"),0);
    }
}
