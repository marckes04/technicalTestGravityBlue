using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPurchasing : MonoBehaviour
{
    public GameObject shoppingCentre;

    void Start()
    {
        shoppingCentre.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Seller")
        {
            shoppingCentre.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void CloseShopping()
    {
       
        shoppingCentre.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BuyPistol()
    {
      
        CloseShopping();
        DeliverItem.instance.SoldPistol();
    }

    public void BuyRifle()
    {
      
        CloseShopping();
      
        DeliverItem.instance.SoldRifle();
      
    }

    public void BuySword()
    {
       
        CloseShopping();
        DeliverItem.instance.SoldSword();
    }
}
