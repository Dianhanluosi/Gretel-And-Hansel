using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip[] clips;
    private float fadeSpeed = 1;
    private AudioSource[] audioSources;
    private indexer trackIndex = 0;
    void Awake()
    {
        if(FindobjectOfType<BGMusic>().Length > 1)
        {
            Destory(gameObject);//to only exist in one copy
        }
        else
        {
            DontDestoryOnLoad(gameObject);
            audioSources = GetComponent<AudioSource>();
        }

        private coid OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            StopAllCoroutine();
            //whatever is fading in before, fades out now
            StartCoroutine(FadeMusic(audioSources[trackIndex],audioSources[trackIndex = 1]- trackIndex], scene.buildIndex));
           //changing the order of the sound track in thee scene matters
        }
        private IEnumerator FadeMusic( AudioSource fadeIn, AudioSource fadeout, int )
    {
        fadeIn.clip = clips[buildIndex];
        fadeIn.Play();
        float t = 0;
        while (t < 1)
        {
            fadeIn.volume = Mathf.Smooth
        }
    }



        

        void OnEnable()
        {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
