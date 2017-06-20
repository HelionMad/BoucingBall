using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    public void ChangeScene(string SceneName)
    {
        Application.LoadLevel(SceneName);
    }
}
