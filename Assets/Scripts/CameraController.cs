using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public Vector3 offset;
    public GameObject POS1;
    private bool cameraAtPOS1;
    public float zoom = 1;



	void Start ()
    {
        offset = transform.position - player.transform.position;
	}

    
	void LateUpdate ()
    {
        if (cameraAtPOS1 == false){
            if (zoom == 1){
                transform.position = player.transform.position + offset;
            } else if (zoom == 2){
                if (SceneManager.GetActiveScene().name == "LevelOne"){
                    transform.position = player.transform.position + offset + new Vector3(0f,-3f,-3f);
                } else if (SceneManager.GetActiveScene().name == "LevelTwo"){
                    transform.position = player.transform.position + offset + new Vector3(-3f,-3f,0f);

                }
            } else if (zoom == 3){
                if (SceneManager.GetActiveScene().name == "LevelOne"){
                    transform.position = player.transform.position + offset + new Vector3(0f,-6f,-6f);
                } else if (SceneManager.GetActiveScene().name == "LevelTwo"){
                    transform.position = player.transform.position + offset + new Vector3(-5f,-5f,0f);

                }
            }
        } else{
            transform.position = POS1.transform.position;
        }
        transform.LookAt(player.transform.position);

	}

    public void cameraPOS1(){
        cameraAtPOS1 = true;
    }
    public void resetCamera(){
        cameraAtPOS1 = false;
    }

    public void ZoomIn(){
        if (zoom == 1){
                zoom = 2;
                } else if (zoom == 2){
                    zoom = 3;
                }
    }
    public void ZoomOut(){
        if (zoom == 3){
                zoom = 2;
            } else if (zoom == 2){
                zoom = 1;
            }
    }
}
