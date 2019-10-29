using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaussCannon : MonoBehaviour
{
  public GameObject m_rocket;
  public float speed = 5f;
  public float rateOfFire = 1;
  public Rigidbody EquippedTo;
  private List<Transform> targets;
  private float shotDelay = 0;

  private void Start() 
  {
      targets = new List<Transform>();
  }

  private void Update() 
  {
      if (shotDelay <= 0)
      {
          if (targets.Count > 0)
          {
              GameObject rocket = Instantiate(m_rocket);
              Rocket script = rocket.GetComponent<Rocket>();
              //script.ignoreCollider = EquippedTo.GetComponent<Collider2D>();
              rocket.GetComponent<Rigidbody>().velocity = EquippedTo.velocity + 
              ((targets[0].position - transform.position).normalized * speed);

              rocket.transform.position = transform.position;
              shotDelay = 1 / rateOfFire;
          }
      }
      else 
      {
          shotDelay -= Time.deltaTime;
      }
  }

  private void OnTriggerEnter(Collider other) 
  {
      if (other != EquippedTo.GetComponent<Collider>())
      {
          targets.Add(other.transform);
      }
  }

  private void OnTriggerExit(Collider other) 
  {
      if (other != EquippedTo.GetComponent<Collider>())
      {
          targets.Remove(other.transform);
      }
  }
}
