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

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        playerPosition=new Vector3(-6,2,0);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {

            if(sceneName[0]=='F') {
                string destinationScene = 'B' + sceneName[1].ToString();
                playerPosition=GameObject.FindGameObjectWithTag("Player").transform.position;
                playerPosition.x=-playerPosition.x;
                Debug.Log(destinationScene);
                SceneManager.LoadScene(destinationScene);
            }
            else if (sceneName[0]=='B') {
                string destinationScene = 'F' + sceneName[1].ToString();
                playerPosition=GameObject.FindGameObjectWithTag("Player").transform.position;
                playerPosition.x=-playerPosition.x;
                Debug.Log(destinationScene);
                SceneManager.LoadScene(destinationScene);
            }

        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        sceneName=scene.name;
        if(sceneName!="Start") {
            Instantiate(myPrefab, playerPosition, Quaternion.identity);
        } 
    }

}
