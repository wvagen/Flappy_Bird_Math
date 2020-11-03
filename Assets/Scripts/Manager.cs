using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    
    public static List<bool> recordedMovement = new List<bool>();
    public static bool isFirstTime = true;
    public static int generation = 1;
    public static int checkPoint = 0;
    public static float speedValue = 1;
    public static int bestFitness = 0;
    public static bool canAutoSkip = false;
    public static bool sucess = false;
    public static string writtenMovements = "";
    public static short stuckAttempt = 0;
    public static int bestFitnessInThisGeneration = 0;


    public static void ShowGenerationAndSetBestFitness(int bestValue)
    {
        if (sucess) return;
        generation++;
        if (bestValue > bestFitness) bestFitness = bestValue;
    }

    public static void FillRecordedMomvementWithWrittenMovment()
    {
        recordedMovement.Clear();
        recordedMovement = new List<bool>();
        for (int i = 0; i < writtenMovements.Length; i++)
        {
            if (writtenMovements[i] == '1') recordedMovement.Add(true);
            else recordedMovement.Add(false);
        }
    }

    public static void ResetAll()
    {
    recordedMovement.Clear();
    recordedMovement = new List<bool>();
    isFirstTime = true;
    generation = 1;
    checkPoint = 0;
    speedValue = 1;
    bestFitness = 0;
    stuckAttempt = 0;
    bestFitnessInThisGeneration = 0;
    writtenMovements = "";
    sucess = false;
    canAutoSkip = false;
    }
}
