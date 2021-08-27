using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Setting_Button : MonoBehaviour
{
    public void OnClickStartButton()
    {
        //SceneManager.LoadScene("Setting_Scene");
        FadeManager.Instance.LoadScene("Setting_Scene", 0.3f);
    }
}
