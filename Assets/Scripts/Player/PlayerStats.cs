using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float health = 100;
    [SerializeField] private TextMeshProUGUI hpText;

    [Header("UI")]
    [SerializeField] private GameObject loseFrame;
    [SerializeField] private GameObject damageVFX;
    [SerializeField] private float vignDecreaseRate = 0.4f;
    private float alpha = 0.0f;

    void Update()
    {
        checkOnHeight();
    }


    public void TakeDamage(float damage)
    {
        health -= damage; 
        hpText.GetComponent<SlowHPUpdate>().NewValue(health);
        if (health <= 0) Death();
        StartCoroutine(TakeDamageEffect());
    }

    private IEnumerator TakeDamageEffect()
    {
        alpha = 1.0f;
        damageVFX.GetComponent<Image>().color = new Color(1.0f,1.0f,1.0f, alpha);

        yield return new WaitForSeconds(0.4f);

        while(alpha > 0)
        {
            alpha -= vignDecreaseRate;
            if (alpha <= 0) alpha = 0;

            damageVFX.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, alpha);

            yield return new WaitForSeconds(0.1f);
        }

        yield break;
    }

    public float GetHealth()
    {
        return health;
    }

    private void checkOnHeight()
    {
        if (transform.position.y <= -10)
            Death();
    }

    public void Death()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        fullLock();
        loseFrame.SetActive(true);
    }

    public void fullLock()
    {
        GetComponent<PlayerMovement>().locked = true;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GameObject _cam = GameObject.Find("MainCamera");
        _cam.GetComponent<ThirdPersonCam>().locked = true;
    }
}
