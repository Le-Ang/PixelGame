using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScale : MonoBehaviour
{
    bool isIncrease = true;

    // Update is called once per frame
    void Update()
    {
        
        if(gameObject.transform.localScale.y >= 3f)
        {
            isIncrease = false;
        }
        else if(gameObject.transform.localScale.y <= 1.5f)
        {
            isIncrease= true;
            
        }
        if (isIncrease)
        {
            gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0);
        }
        else
        {
            gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0);
        }        
        
    }
}
