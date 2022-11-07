using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicControlScript : MonoBehaviour
{
    public static MusicControlScript instance;

    [SerializeField] AudioClip Mainmenugameplay;
    [SerializeField] AudioClip GameOver;
    [SerializeField] AudioClip Victory;
    [SerializeField] AudioSource Audioplayer;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        debugcosito();
    }

    private void debugcosito()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                Audioplayer.clip = Mainmenugameplay;
                break;
            case 1:
                Audioplayer.clip = Mainmenugameplay;
                break;
            case 2:
                Audioplayer.clip = GameOver;
                break;
            case 3:
                Audioplayer.clip = Victory;
                break;
        }

    }
}
