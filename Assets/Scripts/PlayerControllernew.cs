using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllernew : MonoBehaviour
{
    
    public float moveSpeed = 0;
    public float MaxSpeed = 2;
    public float angleSpeed;
   
    
    private void FixedUpdate()
    {
      
        if (Input.GetKey(KeyCode.W))
         {
             if (moveSpeed < MaxSpeed)
             {
                 moveSpeed += 0.05f;
             }
             transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
         }
         if (Input.GetKey(KeyCode.S))
         {

             transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
         }
         if (Input.GetKey(KeyCode.A))
         {
            
            transform.Rotate(-Vector3.up * angleSpeed * Time.deltaTime);
         }
       
        if (Input.GetKey(KeyCode.D))
         {
           
            transform.Rotate(Vector3.up * angleSpeed * Time.deltaTime);
         }
      

    }
   
   
}
