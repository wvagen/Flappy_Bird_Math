using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    public Text scoreText;
    public Text finalScoreText,bestScoreTxt;
    public GameObject gameOverPanel;
    public GameObject tutoImg;
    public Animator canvasAnimator;
    public AudioClip deathSound, flapSound, collectSound;
    public static Rigidbody2D myRig;
    Animator myAnim;
    AudioSource myAudio;
    bool isAlive = true;

    int score = 0;

    // Use this for initialization  
    void Start()
    {
        myRig = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();
        myRig.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (myRig.isKinematic)
            {
                myRig.isKinematic = false;
                tutoImg.SetActive(false);
                scoreText.gameObject.SetActive(true);
            }
            if (isAlive) jump();
        }
        if (this.transform.position.y >= 5.5f ||
            this.transform.position.y <= -5.5f
            ) Die();

    }


    public void Exit()
    {
        Application.Quit();
    }

    public void Retry()
    {

        SceneManager.LoadScene(0);
    }

    private void jump()
    {
        myAudio.PlayOneShot(flapSound);
        myAnim.Play("Tilt", -1, 0);
        myRig.velocity = Vector2.zero;
        myRig.AddForce(Vector2.up * 650);
    }

    void OnCollisionEnter2D()
    {
        Die();
    }
    void Die()
    {
        if (isAlive == false) return;
        isAlive = false;
        myAudio.PlayOneShot(deathSound);
        gameOverPanel.SetActive(true);
        canvasAnimator.Play("GameOver");
        finalScoreText.text = score.ToString();
        scoreText.gameObject.SetActive(false);
        BestScoreHandler();
    }

    void BestScoreHandler()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (bestScore < score)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        bestScoreTxt.text = bestScore.ToString();

    }

    void OnTriggerEnter2D()
    {
        score++;
        myAudio.PlayOneShot(collectSound);
        scoreText.text = score.ToString();
    }

}
