using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] Transform FrontArt;
    [SerializeField] Transform MainTitle;
    [SerializeField] Transform StartButton;
    [SerializeField] Transform QuitButton;

    [SerializeField] Vector3 StartFrontArt = new Vector3(-12,0.6f,0);
    [SerializeField] Vector3 StartMainTitle = new Vector3(-440,112,0);
    [SerializeField] Vector3 StartStartButton = new Vector3(-550,21,0);
    [SerializeField] Vector3 StartQuitButton = new Vector3(-500,-45,0);

    Vector3 TargetFrontArt;
    Vector3 TargetMainTitle;
    Vector3 TargetStartButton;
    Vector3 TargetQuitButton;
    bool coroutineStarted;

    void Awake() 
    {
        //get the target position before moving them out of frame
        GetTargetPos();
        //put them at the target position
        SetStartingPos();
    }


    void Start()
    {
        StartCoroutine(StartingAnimCO());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartingAnimCO()
    {
        if(coroutineStarted){yield return null;}

        coroutineStarted = true;
        yield return new WaitForSeconds(1f);
        FrontArt.LeanMove(TargetFrontArt,1.5f).setEaseOutCubic();
        yield return new WaitForSeconds(1f);
        MainTitle.LeanMoveLocal(TargetMainTitle,2f).setEaseOutCubic();
        StartButton.LeanMoveLocal(TargetStartButton,2f).setEaseOutCubic();
        QuitButton.LeanMoveLocal(TargetQuitButton,2f).setEaseOutCubic();

        coroutineStarted = false;
    }

    private void SetStartingPos()
    {
        FrontArt.position = StartFrontArt;
        MainTitle.localPosition = StartMainTitle;
        StartButton.localPosition = StartStartButton;
        QuitButton.localPosition = StartQuitButton;
    }

    private void GetTargetPos()
    {
        TargetFrontArt = FrontArt.position;
        TargetMainTitle = MainTitle.localPosition;
        TargetStartButton = StartButton.localPosition;
        TargetQuitButton = QuitButton.localPosition;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
