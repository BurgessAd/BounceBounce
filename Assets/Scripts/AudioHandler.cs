using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public  AudioSource audioSource;
    public List<AudioClip> sounds = new List<AudioClip>();
    public static AudioHandler singleton;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        singleton = this;
        DontDestroyOnLoad(audioSource.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    public void CollisionEffect(GameObject gO, Collision c)
    {
        audioSource.clip = sounds[0];
        AudioSource.PlayClipAtPoint(sounds[0], gO.transform.position);
    }


}
