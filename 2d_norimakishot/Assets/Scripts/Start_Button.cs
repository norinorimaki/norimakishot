using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Start_Button : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Level_Select");
    }
}
