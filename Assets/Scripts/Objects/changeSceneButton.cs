using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changeSceneButton : MonoBehaviour
{
    [SerializeField] private Button yourButton;
    [SerializeField] private string NextLevelName;
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene(sceneName: NextLevelName);
    }
}
