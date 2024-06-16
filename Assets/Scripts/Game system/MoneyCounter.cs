using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    public static MoneyCounter instance;

    public Text itemText;
    public static int currentMoney = 0;
    private int nullValue = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        itemText.text = currentMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseCoins(int v)
    {
        currentMoney += v;
        UpdateCoins();
    }


    public void UpdateCoins()
    {
        itemText.text = currentMoney.ToString();
    }
}
