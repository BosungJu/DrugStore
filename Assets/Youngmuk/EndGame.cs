using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    bool loadscene = false;

    public void movescene()
    {
        if (!loadscene)
        {
            loadscene = true;
            SceneManager.LoadScene("End");
        }
    }

}
