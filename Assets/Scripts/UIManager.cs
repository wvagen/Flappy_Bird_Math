using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject InstructionPanel;
    public GameObject Level_Mode_Panel;
    public GameObject Level_Selection_Panel;

    public GameObject nextInstructionPanel;
    public GameObject previousInstructionPanel;

    public Image soundImg;

    public Sprite soundOnSprite, soundOffSprite;

    bool isSoundEnabled = true;

    public void Display_Info_Panel()
    {
        InstructionPanel.SetActive(true);
        Next_Previous_Instrucition_Panel(false);
    }

    public void Hide_Info_Panel()
    {
        InstructionPanel.SetActive(false);
    }

    public void Next_Previous_Instrucition_Panel(bool isNextPanel)
    {
        nextInstructionPanel.SetActive(!isNextPanel);
        previousInstructionPanel.SetActive(isNextPanel);
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Enable_Disable_Sound()
    {
        isSoundEnabled = !isSoundEnabled;

        soundImg.sprite = isSoundEnabled ? soundOnSprite : soundOffSprite;

        AudioListener.pause = !isSoundEnabled;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Close_Level_Mode_Panel()
    {
        Level_Mode_Panel.SetActive(false);
        Level_Selection_Panel.SetActive(false);
    }

    public void NextLvlBtn()
    {
        if (TubeSpawner.levelIndex < TubeSpawner.levelsAmount - 1)
        {
            TubeSpawner.levelIndex++;
            SceneManager.LoadScene("Level_" + (TubeSpawner.levelIndex));
        }
        else
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    public void Quit_To_Main_Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Inifinite_Mode()
    {
        TubeSpawner.isLevel = false;
        SceneManager.LoadScene("Main Game");
    }

    public void Level_Selection()
    {
        Level_Selection_Panel.SetActive(true);
    }

    public void Start_Game()
    {
        Level_Mode_Panel.SetActive(true);
    }

}
