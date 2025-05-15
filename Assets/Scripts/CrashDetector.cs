using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    bool isCrashed=false;
    [SerializeField] float crashDelayAmount=0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX; 
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Ground"&&!isCrashed)
        {
            isCrashed=true;
            FindObjectOfType<PlayerController>().DisableControls();  //yere çarparsak playercontroller scriptimizi bul ve DisableControls()metodumuzu kullan    
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);//play() yerine bunu da kullanabiliriz
            Invoke("ReloadScene",crashDelayAmount);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    
}
