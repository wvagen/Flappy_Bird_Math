using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    public GameObject lockedImg;
    public Button myBtn;
    public int levelIndex;

    void Start()
    {
        if (PlayerPrefs.GetInt("LevelPassed", 0)< levelIndex)
        {
            lockedImg.SetActive(true);
            myBtn.enabled = false;
        }
    }

    public void Select_Level()
    {
        TubeSpawner.isLevel = true;
        TubeSpawner.levelIndex = this.levelIndex;
        SceneManager.LoadScene("Level_" + (levelIndex).ToString());
    }



}
