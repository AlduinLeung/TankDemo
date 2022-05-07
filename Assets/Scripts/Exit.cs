using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
  GameManager gameManager;
  public LayerMask  playerMask;
  private void Awake() {
      gameManager = FindObjectOfType<GameManager>();
  }
  private void OnTriggerEnter2D(Collider2D collision) {
      Debug.Log("test");
      // layer of the player on the collision layer
      if((1<<collision.gameObject.layer & playerMask) != 0) {
          // save data and move to next scene
          gameManager.SaveData();
          gameManager.LoadNextLevel();
      }
  }
}
