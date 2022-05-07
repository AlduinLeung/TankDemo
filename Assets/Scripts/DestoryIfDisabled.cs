using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryIfDisabled : MonoBehaviour
{
    // Start is called before the first frame update
  public bool SelfDestrutionEnabled  {get;set; } = false;
  private void OnDisable() {
      if(SelfDestrutionEnabled){
          Destroy(gameObject);
      }
  }
}
