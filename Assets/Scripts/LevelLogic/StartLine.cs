using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLine : MonoBehaviour
{
    [SerializeField] private GameObject timerText;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.root.CompareTag("Player"))
        {
            timerText.GetComponent<TimerScript>().ActivateTimer();
        }
    }
}
