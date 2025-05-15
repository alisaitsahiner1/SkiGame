using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount=1f;
    [SerializeField] float boostSpeed=70f;
    [SerializeField] float baseSpeed=50f;


    Rigidbody2D rb2D;
    SurfaceEffector2D surfaceEffector2D;

    bool canMove=true;
    // Start is called before the first frame update
    void Start()
    {
        rb2D=GetComponent<Rigidbody2D>();
        surfaceEffector2D=FindObjectOfType<SurfaceEffector2D>();  //Bu tipteki objecti bul ve değişkene ata
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
        RotatePlayer();
        RespondToBoost();
        }
    
    }
    void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed=boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed=baseSpeed;
        }

    }
    void RotatePlayer()
    {
        if(Input.GetKey(KeyCode.LeftArrow)) //girilen tuş sol ok tuşu ise
        {
            rb2D.AddTorque(torqueAmount);  // rigidbodye tork değeri kadar tork ekle
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.AddTorque(-torqueAmount);
        }
    }
    public void DisableControls()
    {
        canMove=false;
    }
}
