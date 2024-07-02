using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyTracker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI moneyChangeText;

    float currentMoney = 0;
    float futureMoney = 0;
    bool coroutineStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        moneyChangeText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = currentMoney.ToString();
    }

    public void MoneyChange(float amount)
    {
        StartCoroutine(MoneyChangeCO(amount));
    }

    IEnumerator MoneyChangeCO(float amount)
    {
        if(coroutineStarted){yield return null;}
        coroutineStarted =true;
        futureMoney+=amount;
        moneyChangeText.text = amount.ToString();
        moneyChangeText.enabled = true;
        yield return new WaitForSeconds(1f);
        while(currentMoney!=futureMoney)
        {
            if(currentMoney<futureMoney)
            {
                currentMoney++;
            }
            else
            {
                currentMoney--;
            }
            yield return new WaitForEndOfFrame();
        }
        moneyChangeText.enabled = false;
        coroutineStarted =false;
    }
}
