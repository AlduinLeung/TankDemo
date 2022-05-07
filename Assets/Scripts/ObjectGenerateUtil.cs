using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerateUtil : MonoBehaviour
{
  public GameObject ObjectPrefab;
  public float radius = 0.2f;


  protected Vector2  GetRandomPosition()
  {
    return Random.insideUnitCircle * radius + (Vector2)transform.position;
  }
  protected Quaternion Random2DRotation()
  {
    return Quaternion.Euler(0, 0, Random.Range(0, 360));
  }
  public void CreateObject(){
      // generate position and rotation
      Vector2 position = GetRandomPosition();
      GameObject  impactObject = GetObject();
        impactObject.transform.position = position;
        impactObject.transform.rotation = Random2DRotation();
  }
  protected GameObject GetObject()
  {
    return Instantiate(ObjectPrefab);
  }

  private void OnDrawGizmos() {
      Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
  }
}
