using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource gamePlayAudio;
    [SerializeField] public AudioSource playerDeathAudio;
    [SerializeField] public AudioSource menuAudio;
    [SerializeField] public AudioSource gameOverAudio;


    public static AudioManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        menuAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDeathSound()
    {
        playerDeathAudio.Play();
    }

    public void PlayMainMenuSound()
    {
        menuAudio.Play();
    }


}
