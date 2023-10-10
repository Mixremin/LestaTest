using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePillar : MonoBehaviour
{
    [SerializeField] private bool goLeft = true;
    [SerializeField] private Vector3 pos1 = new Vector3(0, 0, 1.5f);
    [SerializeField] private Vector3 pos2 = new Vector3(0, 0, -1.5f);
    public float speed = 1.0f;

    void Update()
    {
        if(goLeft) transform.GetChild(0).localPosition = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
        else transform.GetChild(0).localPosition = Vector3.Lerp(pos2, pos1, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
