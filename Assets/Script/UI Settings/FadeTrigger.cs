using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTrigger : MonoBehaviour
{
    public SceneChanger SceneChange;
    //public PlayerAttack PlayerAttack;
    //public GameObject Player;
    public string SceneName;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player Changing scene");
            //Player.tag = "PlayerBusy";
            //PlayerAttack.enabled = false;
            SceneChange.ChangeSceneWithFade(SceneName);
        }
    }

    public void TurnPlayerBackOn()
    {
        //Player.tag = "Player";
        //PlayerAttack.enabled = true;
    }
}