using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageTrap : MonoBehaviour
{
    [SerializeField] private Renderer m_Renderer;
    [SerializeField] private float damage = 10.0f;

    [Header("Materials")]
    [SerializeField] private Material original;
    [SerializeField] private Material orange;
    [SerializeField] private Material red;

    [Header("CoolDowns")]
    [SerializeField] private float warningCD = 1;
    [SerializeField] private float trapCD = 5;

    [Header("Counters(Don't Touch)")]
    [SerializeField] private float warningTime = 0;
    [SerializeField] private float trapTime = 0;

    [Header("Trap State")]
    [SerializeField] private TrapState state = TrapState.Preparing;
    // Start is called before the first frame update
    public enum TrapState { Preparing, Warning, Activated }
    private bool trigger = false;

    private void Start()
    {
        m_Renderer = gameObject.GetComponent<Renderer>();
        warningTime = warningCD;
        trapTime = trapCD;
    }

    private void Update()
    {
        switch(state)
        {
            case TrapState.Preparing:
                warningTime = warningCD;
                trapTime = trapCD;
                return;
            case TrapState.Warning:
                warningTime -= Time.deltaTime;
                break;
            case TrapState.Activated:
                trapTime -= Time.deltaTime;
                break;
        }
        StateTimeChanger();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (state == TrapState.Preparing)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                state = TrapState.Warning;
                m_Renderer.material = orange;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (state != TrapState.Preparing)
        {
            if (trigger)
            {
                Debug.Log("Checking for players");
                if (other.gameObject.CompareTag("Player"))
                {
                    Debug.Log("Applying damage to players");
                    other.GetComponent<PlayerStats>().TakeDamage(damage);
                    trigger = false;
                }
            }
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            state = TrapState.Warning;
            m_Renderer.material = orange;
        }
    }
    
    private void StateTimeChanger()
    {
        if(warningTime <= 0)
        {
            trigger = true;
            m_Renderer.material = red;
            Invoke("ReturnToNormal",0.5f);
            state = TrapState.Activated;
            Debug.Log("Reset warning timer");
            warningTime = warningCD;    
        }

        if (trapTime <= 0)
        {
            state = TrapState.Preparing;
            trapTime = trapCD;
        }
    }

    private void ReturnToNormal()
    {
        m_Renderer.material = original;
        trigger = false;
    }


    //StartCoroutine(damageCooldown(other));

    //private IEnumerator damageCooldown(Collider other)
    //{
    //    yield return new WaitForSeconds(warningCD);
    //    m_Renderer.material = red;
    //    yield return new WaitForSeconds(0.5f);
    //    m_Renderer.material = original;
    //    yield return new WaitForSeconds(afterDamageCD);
    //}
}
