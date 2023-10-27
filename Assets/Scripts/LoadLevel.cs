using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("PlayScene");  
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("StartScene");  
    }

}
