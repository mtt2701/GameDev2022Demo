using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject myPrefab;
    private string sceneName;
    private Vector3 playerPosition;
    private string foldState;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(sceneName!="Start") {
            playerPosition=GameObject.FindGameObjectWithTag("Player").transform.position;
            if (Input.GetKeyDown(KeyCode.S)) {
                string nextScene="";
                if (playerPosition.x<-6)
                    nextScene=NextSceneLeft();
                if (playerPosition.x>6)
                    nextScene=NextSceneRight();
                if(nextScene!="") {
                    playerPosition.x=-playerPosition.x;
                    Debug.Log(nextScene);
                    SceneManager.LoadScene(nextScene);
                }
            }
            if (Input.GetKeyDown(KeyCode.E)) {
                if(sceneName=="F2") {
                    if (playerPosition.x<-6) {
                        if(foldState=="")
                            foldState="F2L";
                        else if(foldState=="F2L")
                            foldState="";
                    }
                    if (playerPosition.x>6) {
                        if(foldState=="")
                            foldState="F2R";
                        else if(foldState=="F2R")
                            foldState="";
                    }   
                }
                if(sceneName=="B2") {
                    if (playerPosition.x<-6) {
                        if(foldState=="")
                            foldState="B2L";
                        else if(foldState=="B2L")
                            foldState="";
                    }
                    if (playerPosition.x>6) {
                        if(foldState=="")
                            foldState="B2R";
                        else if(foldState=="B2R")
                            foldState="";
                    }   
                }
                Debug.Log(foldState);
            }
            if (Input.GetKeyDown(KeyCode.F)) {
                playerPosition.x=-playerPosition.x;
                Debug.Log(OppositeScene());
                SceneManager.LoadScene(OppositeScene());
            }
        }
    }

    string NextSceneLeft()
    {
        if(sceneName=="F2") {
            if(foldState!="F2L")
                return "F2";
        }
        if(sceneName=="F3") {
            if(foldState=="B2R")
                return "B1";
            if(foldState!="F2R")
                return "F2";
        }
        if(sceneName=="B2") {
            if(foldState!="B2L")
                return "B3";
        }
        if(sceneName=="B1") {
            if(foldState=="F2R")
                return "F3";
            if(foldState!="B2R")
                return "B2";
        }
        return "";
    }

    string NextSceneRight()
    {
        if(sceneName=="F2") {
            if(foldState!="F2R")
                return "F3";
        }
        if(sceneName=="F1") {
            if(foldState=="B2L")
                return "B3";
            if(foldState!="F2L")
                return "F2";
        }
        if(sceneName=="B2") {
            if(foldState!="B2R")
                return "B1";
        }
        if(sceneName=="B3") {
            if(foldState=="F2L")
                return "F1";
            if(foldState!="B2L")
                return "B2";
        }
        return "";
    }

    string OppositeScene() 
    {
        if(foldState=="F2L") {
            if(sceneName=="F2")
                return "F1";
            if(sceneName=="F1")
                return "F2";
        }
        if(foldState=="F2R") {
            if(sceneName=="F2")
                return "F3";
            if(sceneName=="F3")
                return "F1";
        }
        if(foldState=="B2L") {
            if(sceneName=="B2")
                return "B3";
            if(sceneName=="B3")
                return "B2";
        }
        if(foldState=="B2R") {
            if(sceneName=="B2")
                return "B1";
            if(sceneName=="B1")
                return "B2";
        }
        if(sceneName[0]=='F')
            return 'B' + sceneName[1].ToString();
        return 'F' + sceneName[1].ToString();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        sceneName=scene.name;
        if(sceneName=="Start") {
            playerPosition=new Vector3(-6,2,0);
            foldState="";
        }
        if(sceneName!="Start") {
            Instantiate(myPrefab, playerPosition, Quaternion.identity);
        } 
    }

}
