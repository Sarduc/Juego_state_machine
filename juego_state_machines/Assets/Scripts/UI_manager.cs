using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    private TextMeshProUGUI txtObj;
    player_movement player;
    void Start()
    {
        txtObj = GameObject.Find("textisimo").GetComponent<TextMeshProUGUI>();
        player = GameObject.FindWithTag("Player").GetComponent<player_movement>();
    }


    private void Update()
    {
        txtObj.text = player.hp.ToString();
    }
}
