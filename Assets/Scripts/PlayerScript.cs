using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    Rigidbody playerRb;
    Transform playerTransform;  

    bool isGameStarted;
    public float speed;
    public float sensitivity;
    public int score;

    public TextMeshProUGUI scoreText;
    

    private float minX = -4.5f;
    private float maxX = 4.5f;

    public GameObject mainMenuPanel;
    public GameObject failMenuPanel;
    public GameObject successMenuPanel;
    public GameObject joysticPanel;

    public FloatingJoystick floatingJS;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();

        mainMenuPanel.SetActive(true);
    }


    void Update()
    {
        if (isGameStarted == true)
        {
            PlayerMove();
        }

        if (score == 10)
        {
            ShowSuccessMenuPanel();
        }

        if (score == -1)
        {
            ShowFailMenuPanel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            score--;
            scoreText.text = "Score : " + score.ToString();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Coin")
        {
            score++;
            scoreText.text = "Score : " + score.ToString();
            Destroy(other.gameObject);        
        }
    }

    private void PlayerMove()
    {
        if (isGameStarted == true)
        {
            playerTransform.position += new Vector3(floatingJS.Horizontal * sensitivity, 0, speed * Time.deltaTime);
            float xPosition = Mathf.Clamp(transform.position.x, minX, maxX);
            transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
        }
    }

    private void ShowMainMenuPanel()
    {
        isGameStarted = false;
        mainMenuPanel.SetActive(true);
    }

    private void ShowFailMenuPanel()
    {
        isGameStarted = false;
        failMenuPanel.SetActive(true);
        joysticPanel.SetActive(false);
    }

    private void ShowSuccessMenuPanel()
    {
        isGameStarted = false;
        successMenuPanel.SetActive(true);     
        joysticPanel.SetActive(false);
    }

    public void StartButtonTapped()
    {
        mainMenuPanel.SetActive(false);
        joysticPanel.SetActive(true);
        isGameStarted = true;       
    }

    public void RestartButtonTapped()
    {
        isGameStarted = true;
        failMenuPanel.SetActive(false);
        successMenuPanel.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }

 
}
