using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    public Enemy smallbg;
    public Enemy bigbg;
    public Purse purse;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.name == "BigBadGuy")
                {
                    bigbg.health--;
                    Debug.Log($"Health: {bigbg.health}");
                    if(bigbg.health <= 0)
                    {
                        Destroy(hit.transform.gameObject);
                        purse.coins += bigbg.coinWorth;
                    }

                }
                if (hit.transform.gameObject.name == "SmallBadGuy")
                {
                    smallbg.health--;
                    Debug.Log($"Health: {smallbg.health}");
                    if (smallbg.health <= 0)
                    {
                        Destroy(hit.transform.gameObject);
                        purse.coins += smallbg.coinWorth;
                    }
                }
                
                
            }
        }

    }
}
