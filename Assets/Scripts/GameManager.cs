using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float myTime = 0;
    [SerializeField] private TextMeshProUGUI timmer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        calcTime();
    }

    private void calcTime(){
        myTime += Time.deltaTime;
        float min = Mathf.FloorToInt(myTime/60);
        float sec = Mathf.FloorToInt(myTime%60);
        //Debug.Log(string.Format("{0:00}:{1:00}",min,sec));
        timmer.text = string.Format("{0:00}:{1:00}",min,sec);
    }
}
