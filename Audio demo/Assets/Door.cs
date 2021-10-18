using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEner(Collider other)
    {
        if (other..ComparedTag("Player"))
        {
            //it will load the scene when you tell it to load


            asyncOperation = SceneManager.LoadSceneAsync(levelName);
            asyncOperation.allowSceneActivation = false;
            fader.CrossFadeAlpha(1, 1, true);
            StartCoroutine(LoadNext());
        }
    }
}
