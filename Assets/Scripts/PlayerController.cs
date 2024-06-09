using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //needed to restart the game when the player enters the death zone (trigger event)
using TMPro;

public class PlayerController : MonoBehaviour
{

    //These public variables are initialized in the Inspector
    public float jumpspeed = 600f;
    public float speed;
    public TMP_Text countText;
    public TMP_Text winText;
    public TMP_Text timeText;  //  variable to display the timer text in Unity
    //public float startingTime;  // variable to hold the game's starting time
    //public string min;
    //public string sec;

    //These private variables are initialized in the Start
    private Rigidbody rb;
    private int count;
    private bool gameOver; //  bool to define game state on or off.
    string currentSceneName;
    //private float timer;

    // Audio
    public AudioClip coinSFX;
    private AudioSource audioSource;
    public CameraController cameraCon;
    public bool playerInZone1 = false;
    public AudioClip explosion; 
    public GameObject destroyableMachine;
    public GameObject destroyableSmoke;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        gameOver = false;

        audioSource = GetComponent<AudioSource>();  // access the audio source component of player

        if (SceneManager.GetActiveScene().name == "LevelOne"){
            TimeKeeper.instance.startingTime1 = Time.time;
            TimeKeeper.instance.level1 = true;
        } else if (SceneManager.GetActiveScene().name == "LevelTwo"){
            TimeKeeper.instance.startingTime2 = Time.time;
            TimeKeeper.instance.level2 = true;
        }


    }
            
    private void Update()
    {
        if (gameOver) // condition that the game is NOT over; returns the false value
            return;

        if (SceneManager.GetActiveScene().name == "LevelOne"){
            string min = TimeKeeper.instance.min1;
            string sec = TimeKeeper.instance.sec1;
            timeText.text = "Elapsed Time: " + min + ":" + sec;     // update UI time text
        } else if (SceneManager.GetActiveScene().name == "LevelTwo"){
            string min = TimeKeeper.instance.min2;
            string sec = TimeKeeper.instance.sec2;
            timeText.text = "Elapsed Time: " + min + ":" + sec; 
        }
        Debug.Log("timer2: " + TimeKeeper.instance.timer2);
        Debug.Log("realtime: " + Time.time);
        Debug.Log("starting time: " + TimeKeeper.instance.startingTime2);
    }        


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (!playerInZone1){
            if (SceneManager.GetActiveScene().name == "LevelOne"){
                Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
                rb.AddForce(movement * speed);
            } else if (SceneManager.GetActiveScene().name == "LevelTwo"){
                Vector3 movement = new Vector3(-moveVertical, 0.0f, moveHorizontal);
                rb.AddForce(movement * speed);

            }
        } else {
            Vector3 movement = new Vector3(moveVertical, 0.0f, -moveHorizontal);
            rb.AddForce(movement * speed);
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        //This event/function handles trigger events (collsion between a game object with a rigid body)
   
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();

            //PLAY SOUND EFFECT
            audioSource.clip = coinSFX;
            audioSource.Play();

        }

        if (other.gameObject.CompareTag("DeathZone"))
        {
            currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        if (other.gameObject.CompareTag("Grow"))
        {
            {
                if (SceneManager.GetActiveScene().name == "LevelOne"){
                    transform.localScale *= 2f;    // increase scale by 25% - Bryson "Changed to 50 for testing"
                } else if (SceneManager.GetActiveScene().name == "LevelTwo"){
                    if (transform.localScale.x < 2){
                        transform.localScale *=2f;
                    }
                }
                other.gameObject.GetComponent<AudioSource>().Play();
                cameraCon.ZoomOut();
            }
        }

        if (other.gameObject.CompareTag("Shrink"))
        {
            if (transform.localScale.x >= 0.5f)
            {
                transform.localScale *= 0.25f;     // decreases scale by 25% - Bryson "Changed to 50 for testing"
                other.gameObject.GetComponent<AudioSource>().Play();
            }
                cameraCon.ZoomIn();
        }

        if (other.gameObject.CompareTag("Jump"))
        {
            rb.AddForce(new Vector3(0.0f, jumpspeed, 0.0f));
        }
        if (other.gameObject.CompareTag("SuperJump"))
        {
            rb.AddForce(new Vector3(0.0f, jumpspeed * 2.25f, 0.0f));
        }
        if (other.gameObject.CompareTag("cameraZone1")){
            cameraCon.cameraPOS1();
            playerInZone1 = true;
        }

        if (other.gameObject.CompareTag("Smoke")){
            gameObject.SetActive(false);
            destroyableSmoke.GetComponent<AudioSource>().Play();
            Invoke("RestartLevel", 1.5f);
        }

        if (other.gameObject.CompareTag("Machine")){
            Debug.Log("hit machine!");
            if (transform.localScale.x >= 2){
                destroyableMachine.gameObject.GetComponent<AudioSource>().Play();
                Invoke("DestroyMachine", 1.3f);
            }
        }


        if (other.gameObject.CompareTag("Spider")){
            gameObject.SetActive(false);
            Invoke("RestartLevel", 0.7f);
        }

        if (other.gameObject.CompareTag("Platform")){
            transform.parent = other.transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("cameraZone1")){
            cameraCon.resetCamera();
            playerInZone1 = false;

        }
        
        /*
        if (other.gameObject.CompareTag("Platform")){
            transform.parent = null;
        }*/
    }


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 9)
        {
            gameOver = true; // returns true value to signal game is over
            timeText.color = Color.green;  // changes timer's color
            winText.text = "You win!";
            speed = 0;


            SceneManager.LoadScene("WIN");

        }
    }

    void DestroyMachine(){
        destroyableMachine.SetActive(false);
        destroyableSmoke.SetActive(false);
    } 

    void RestartLevel(){
        SceneManager.LoadScene(currentSceneName);
    }
}
