using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
   public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
