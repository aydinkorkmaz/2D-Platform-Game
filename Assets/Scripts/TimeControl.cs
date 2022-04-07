using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeControl : MonoBehaviour
{[SerializeField]Text timertext;
[SerializeField]float timervalue;
    
    void Start()
    {
        timertext.text=timervalue.ToString();
    }

    // Update is called once per frame
    void Update()
    {   if(timervalue>0){
        timervalue-=Time.deltaTime;
        timertext.text=((int)timervalue).ToString();
        if(timervalue<=0){
            GetComponent<PlayerController>().Die();
        }
    }
        
    }
}
