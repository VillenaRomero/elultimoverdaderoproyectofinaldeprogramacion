using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    public Text textpoints;
    public int points;
    public int pointsPerSecond = 1;
    public float timeTiCreate = 1;
    public float currentTimetuCreate;

    void Update()
    {
        currentTimetuCreate = currentTimetuCreate + Time.deltaTime;
        if (currentTimetuCreate >= timeTiCreate)
        {
            IncreasePoints();

            currentTimetuCreate = 0;
        }
    }
    void IncreasePoints()
    {
        points += pointsPerSecond;
        textpoints.text = "Tiempo: " + points;
    }
}
