using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Sprite[] HeartSprites;

    public Image HeartsUI;

    private player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }

    void Update()
    {
        HeartsUI.sprite = HeartSprites[player.curHealth];
    }
}
