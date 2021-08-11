using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.IO;
using UnityEditor;

public class MainUIHandler : MonoBehaviour
{
    public TMP_InputField nameInput;
    

    // Start is called before the first frame update
    void Start()
    {
        PersistenceManager.Instance.LoadScore();
        nameInput.text = PersistenceManager.Instance.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartNew()
    {
        // Take input from text entry space and set playername
        ChangeName();
        SceneManager.LoadScene(1);
    }

    void ChangeName()
    {
        PersistenceManager.Instance.ChangeName(nameInput.text);
    }

    public void Exit()
    {
        // Saves last selected color when application is closed
        PersistenceManager.Instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
