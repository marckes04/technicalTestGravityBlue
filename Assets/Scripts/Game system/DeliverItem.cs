using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverItem : MonoBehaviour
{
    public static DeliverItem instance;

    [SerializeField]
    private GameObject sword, pistol, rifle;

    private void Awake()
    {
        instance = this;
    }

    public void SoldSword()
    {
        if (MoneyCounter.currentMoney >= 120)
        {
            MoneyCounter.currentMoney -= 120;
            sword.SetActive(true);
            // Optionally, add feedback for successful purchase
            Debug.Log("Sword purchased!");
        }
        else
        {
            // Optionally, add feedback for insufficient funds
            Debug.Log("Not enough money to purchase the sword.");
        }
    }

    public void SoldPistol()
    {
        if (MoneyCounter.currentMoney >= 50)
        {
            MoneyCounter.currentMoney -= 50;
            pistol.SetActive(true);
            // Optionally, add feedback for successful purchase
            Debug.Log("Pistol purchased!");
        }
        else
        {
            // Optionally, add feedback for insufficient funds
            Debug.Log("Not enough money to purchase the pistol.");
        }
    }

    public void SoldRifle()
    {
        if (MoneyCounter.currentMoney >= 80)
        {
            MoneyCounter.currentMoney -= 80;
            rifle.SetActive(true);
            // Optionally, add feedback for successful purchase
            Debug.Log("Rifle purchased!");
        }
        else
        {
            // Optionally, add feedback for insufficient funds
            Debug.Log("Not enough money to purchase the rifle.");
        }
    }
}
