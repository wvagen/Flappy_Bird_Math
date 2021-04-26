using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    public Material bgMat;

    public Text scoreText;
    public Text finalScoreText, bestScoreTxt;
    public GameObject gameOverPanel, losePanel;
    public GameObject tutoImg;
    public Animator canvasAnimator;
    public AudioClip deathSound, flapSound, collectSound;
    public static Rigidbody2D myRig;

    public float jumpForce = 650f;

    Animator myAnim;
    AudioSource myAudio;
    bool isAlive = true;

    Vector2 offset = Vector2.zero;

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
        if (this.transform.position.y >= 5.5f ||
            this.transform.position.y <= -5.5f
            )
        {
            if (TubeSpawner.isLevel) Lose();
            else Die();
        }

        if (!myRig.isKinematic)
        {
            offset.x -= Time.deltaTime * 0.1f;
            bgMat.SetTextureOffset("_MainTex", offset);
        }

        if (TubeSpawner.isLevel && score >= TubeSpawner.tubeGenerateAmount)
        {
            Die();
            if (PlayerPrefs.GetInt("LevelPassed", 1) < TubeSpawner.levelIndex)
            {
                PlayerPrefs.SetInt("LevelPassed", TubeSpawner.levelIndex);
            }
        }

    }


    public void JumpOnClick()
    {
        if (myRig.isKinematic)
        {
            myRig.isKinematic = false;
            tutoImg.SetActive(false);
            scoreText.gameObject.SetActive(true);
        }
        if (isAlive) Jump();
    }

    public void Jump()
    {
        myAudio.PlayOneShot(flapSound);
        myAnim.Play("Tilt", -1, 0);
        myRig.velocity = Vector2.zero;
        myRig.AddForce(Vector2.up * jumpForce);
    }

    void OnCollisionEnter2D()
    {
        if (TubeSpawner.isLevel)
        {
            Lose();
        }
        else
        {
            Die();
        }

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

    void Lose()
    {
        if (isAlive == false) return;
        isAlive = false;
        myAudio.PlayOneShot(deathSound);
        gameOverPanel.SetActive(true);
        losePanel.SetActive(true);
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("enemy"))
        {
            Lose();
        }
        else
        {
            score++;
            myAudio.PlayOneShot(collectSound);
            scoreText.text = score.ToString();
        }

    }

}
