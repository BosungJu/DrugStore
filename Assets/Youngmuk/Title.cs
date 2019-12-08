using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Title : MonoBehaviour
{
    public GameObject fadeinout;

    public void movescene()
    {
        if(!fadeinout.activeSelf)
        {
            StartCoroutine(Scene());
            fadeinout.SetActive(true);
        }
    }

    IEnumerator Scene()
    {
        yield return new WaitForSeconds(0.55f);
        SceneManager.LoadScene("narration");
    }
}
