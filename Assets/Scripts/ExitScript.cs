using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ExitScript : MonoBehaviour
{

    public void Exit()
    {

        GameManager.Instance.SaveBestScore();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }


}
