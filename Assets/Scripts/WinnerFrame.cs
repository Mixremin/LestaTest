using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerFrame : MonoBehaviour
{
    [SerializeField] private GameObject timerText;
    [SerializeField] private TextMeshProUGUI finalTimeText;
    private float finalTime;
    // Start is called before the first frame update
    public void showFrame()
    {
        gameObject.SetActive(true);
        finalTime = timerText.GetComponent<TimerScript>().returnTime();
        int hours = Mathf.FloorToInt(finalTime / 3600);
        int minutes = Mathf.FloorToInt(finalTime / 60);
        int seconds = Mathf.FloorToInt(finalTime % 60);
        finalTimeText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
