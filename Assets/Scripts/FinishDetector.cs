using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //sahneleri ayarlamak için bu namespacei eklememiz gerekli

public class FinishDetector : MonoBehaviour
{
    [SerializeField] float delayAmount=2f;
    [SerializeField] ParticleSystem finishEffect; //efektimizi değişkene referans verdik

   void OnTriggerEnter2D(Collider2D other)
   {
    if(other.tag=="Player")
    {
       finishEffect.Play();   //efektimizi oynat
       GetComponent<AudioSource>().Play(); //audiosource componentine ulaşıp oynat
       Invoke("ReloadScene",delayAmount); //reloadscene metotunu gecikme süresi kadar ertele
    }
   }
   void ReloadScene()
   {
       SceneManager.LoadScene(0);  //bitiş çizgisine player gelirse 0. sahneyi yükle
   }
}
