using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlowHPUpdate : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public float countDuration = 1;
    TextMeshProUGUI numberText;
    float currentValue = 0, targetValue = 0;
    Coroutine _C2T;

    void Awake()
    {
        numberText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        currentValue = Player.GetComponent<PlayerStats>().GetHealth();
        targetValue = currentValue;
    }

    IEnumerator CountTo(float targetValue)
    {
        var rate = Mathf.Abs(targetValue - currentValue) / countDuration;
        while (currentValue != targetValue)
        {
            currentValue = Mathf.MoveTowards(currentValue, targetValue, rate * Time.deltaTime);
            numberText.text = ((int)currentValue).ToString();
            yield return null;
        }
    }

    public void NewValue(float value)
    {
        targetValue = value;
        if (_C2T != null)
            StopCoroutine(_C2T);
        _C2T = StartCoroutine(CountTo(targetValue));
    }
}
