#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

#if UNITY_5_3_OR_NEWER
using UnityEngine.SceneManagement;
#endif

using System;

[Serializable]
public class InputManager : Singleton<InputManager> {

    // Set to protected to prevent calling constructor
    protected InputManager() { }

    public KeyCode restartGameKey = KeyCode.R;
    public KeyCode resetUnitsKey = KeyCode.Delete;
    public KeyCode resetAchievementsKey = KeyCode.End;

    public Fade fade;

    Scene m_CurrentScene;

    void Start()
    {
        m_CurrentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if (Input.GetKeyUp(restartGameKey))
        {
            Restart();
        }

        if (Input.GetKeyUp(resetUnitsKey))
        {
            DataManager.ResetUnits();
        }

        if (Input.GetKeyUp(resetAchievementsKey))
        {
            AchievementManager.Instance.Reset();
        }
    }

    public void Restart()
    {
        fade.FadeTo(1.0f);
#if UNITY_5_3_OR_NEWER
        SceneManager.LoadScene(m_CurrentScene.buildIndex);
#else
        Application.LoadLevel(Application.loadedLevel);   
#endif
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ResetUnits()
    {
        DataManager.ResetUnits();
    }
}
