using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float myTime = 0;
    [SerializeField] private TextMeshProUGUI timmerTxt;
    [SerializeField] private TextMeshProUGUI endTime;
    [SerializeField] private GameObject endGameUi;
    public bool isInProgress = true;
    private float minutes;
    private float seconds;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
        if(!isInProgress) {
            endGameUi.SetActive(true);
            endTime.text = "Your time is " + string.Format("{0:00}:{1:00}", minutes,seconds);
        }else{
            calcTime(); //ABSTRACTION
        }
    }

    private void calcTime(){
        myTime += Time.deltaTime;
        minutes = Mathf.FloorToInt(myTime/60);
        seconds = Mathf.FloorToInt(myTime%60);
        timmerTxt.text = string.Format("{0:00}:{1:00}", minutes,seconds);
    }

    public void BackToTitle(){
        SceneManager.LoadScene(0);
    }

    public void PlayAgain(){
        SceneManager.LoadScene(1);
    }
}
