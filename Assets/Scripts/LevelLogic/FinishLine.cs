using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameObject timerText;
    [SerializeField] private GameObject winnerFrame;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.root.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().fullLock();
            timerText.GetComponent<TimerScript>().DeactivateTimer();
            winnerFrame.GetComponent<WinnerFrame>().showFrame();
        }
    }
}
