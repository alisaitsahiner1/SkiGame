using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField ]ParticleSystem dustTrailEffect;
   
        void OnCollisionEnter2D (Collision2D other)
        {
            dustTrailEffect.Play();
        }
        void OnCollisionExit2D (Collision2D other) //çarpışmadan çıkınca
        {
            dustTrailEffect.Stop();  //animasyonu durdur
        }
        
    
}
