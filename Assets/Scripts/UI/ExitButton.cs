using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExitButton : MonoBehaviour {
    // Start is called before the first frame update
    public void Quit() {
        EditorApplication.isPlaying = false;
    }
}
