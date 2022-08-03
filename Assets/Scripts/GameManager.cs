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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        calcTime();
        if(!isInProgress) {
            endGameUi.SetActive(true);
            endTime.text = "Your time is " + timmerTxt.text;
        }
    }

    private void calcTime(){
        myTime += Time.deltaTime;
        float min = Mathf.FloorToInt(myTime/60);
        float sec = Mathf.FloorToInt(myTime%60);
        timmerTxt.text = string.Format("{0:00}:{1:00}",min,sec);
    }

    public void BackToTitle(){
        SceneManager.LoadScene(0);
    }

    public void PlayAgain(){
        SceneManager.LoadScene(1);
    }
}
