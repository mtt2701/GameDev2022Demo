using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    //Check out https://kdw.itch.io/dimensionrush
    public string sceneName;
    public string location;
    public string nextPoint;
    public void EndOpen()
    {
        gameObject.GetComponent<Animator>().SetBool("opening", false);
    }

    public void EndClose()
    {
        gameObject.GetComponent<Animator>().SetBool("closing", false);
    }
    // Start is called before the first frame update
    void Start()
    {
        sceneName = sceneName ?? "NoneAvailable";
        if((PlayerPrefs.GetString("entryPoint") == location) && !string.IsNullOrEmpty(location))
        {
            FindObjectOfType<PlayerController>().gameObject.transform.position = transform.position;
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        sceneName = sceneName ?? "NoneAvailable";
        //Checks what entrance is listed in the Player References which possesses data accessible throughout scenes
        if ((PlayerPrefs.GetString("entryPoint") == location) && !string.IsNullOrEmpty(location))
        {
            //Changes Player Location
            FindObjectOfType<PlayerController>().gameObject.transform.position = transform.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
