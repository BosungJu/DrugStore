using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class narration : MonoBehaviour
{
    bool loadscene = false;

    private void Start()
    {
        StartCoroutine("Scene");
    }

    public void movescene()
    {
        if (!loadscene)
        {
            StopCoroutine("Scene");
            loadscene = true;
            SceneManager.LoadScene("BulletinBoard");
        }
    }

    IEnumerator Scene()
    {
        if(!loadscene)
        {
            yield return new WaitForSeconds(20f);
            SceneManager.LoadScene("BulletinBoard");
        }
    }
}
