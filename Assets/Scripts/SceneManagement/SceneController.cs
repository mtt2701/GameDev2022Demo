using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    protected static SceneController instance;

    public static SceneController Instance
    {
        get
        {
            if (instance != null)
                return instance;
            instance = FindObjectOfType<SceneController>();
            if (instance != null)
                return instance;
            GameObject sceneControllerGameObject = new GameObject("SceneController");
            instance = sceneControllerGameObject.AddComponent<SceneController>();
            return instance;
        }
    }

    public SceneTransitionDestination initialSceneTransitionDestination;

    void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        if (initialSceneTransitionDestination != null)
        {
            SetEnteringGameObjectLocation(initialSceneTransitionDestination);
            initialSceneTransitionDestination.OnReachDestination.Invoke();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    protected void SetEnteringGameObjectLocation(SceneTransitionDestination entrance)
    {
        if (entrance == null)
        {
            Debug.LogWarning("Entering Transform's location has not been set.");
            return;
        }
        Transform entranceLocation = entrance.transform;
        Transform enteringTransform = entrance.transitioningGameObject.transform;
        enteringTransform.position = entranceLocation.position;
        enteringTransform.rotation = entranceLocation.rotation;
    }
}
