using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentDataManager : MonoBehaviour
{
    public static PersistentDataManager Instance
    {
        get
        {
            if (instance != null)
                return instance;
            instance = FindObjectOfType<PersistentDataManager>();
            if (instance != null)
                return instance;
            Create();
            return instance;
        }
    }

    protected static PersistentDataManager instance;

    public static PersistentDataManager Create()
    {
        GameObject dataManagerGameObject = new GameObject("PersistentDataManager");
        DontDestroyOnLoad(dataManagerGameObject);
        instance = dataManagerGameObject.AddComponent<PersistentDataManager>();
        return instance;
    }

    void Awake()
    {
        if (Instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
