using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderBounce : MonoBehaviour
{
 private Rigidbody2D rigidbodyPlayer;

 public int force;

 private void Start() 
 {
     rigidbodyPlayer = GetComponent<Rigidbody2D>();
 }
 private void OnCollisionEnter2D(Collision2D other) 
 {
     if (other.gameObject.tag == "TopBoundary")
     {
         rigidbodyPlayer.AddForce(Vector2.down * force);
     }
     else if (other.gameObject.tag == "BottomBoundary")
     {
         rigidbodyPlayer.AddForce(Vector2.up * force);
     }
     else if (other.gameObject.tag == "RightBoundary")
     {
         rigidbodyPlayer.AddForce(Vector2.left * force);
     }
     else if (other.gameObject.tag == "LeftBoundary")
     {
         rigidbodyPlayer.AddForce(Vector2.right * force);
     }
 }
}
