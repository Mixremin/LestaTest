using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    
    [SerializeField] private bool activated = false;
    [SerializeField] private TextMeshProUGUI timerText;

    private float elapsedTime;
    private bool finished = false;

    void Update()
    {
        int hours = Mathf.FloorToInt(elapsedTime / 3600);
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        if (activated)
        {
            elapsedTime += Time.deltaTime;            
            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        } else if (finished)
        {
            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        }
    }

    public void ActivateTimer()
    {
        activated = true;
    }
    public void DeactivateTimer()
    {
        activated = false;
        finished = true;
    }

    public float returnTime()
    {
        return elapsedTime;
    }
}
