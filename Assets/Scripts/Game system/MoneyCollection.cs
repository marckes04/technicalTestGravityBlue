using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollection : MonoBehaviour
{
     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            MoneyCounter.instance.IncreaseCoins(1);
            Destroy(other.gameObject);
        }
    }
}
