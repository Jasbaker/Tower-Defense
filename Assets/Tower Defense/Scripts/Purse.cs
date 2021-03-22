using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Purse : MonoBehaviour
{
    public int coins;
    public Text amount;

    void Awake()
    {
        coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        amount.text = coins.ToString();
        
    }
}
