using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRandomizer : MonoBehaviour
{
    SpriteRenderer mySprite;
    public Sprite stone;
    public Sprite water;
    public Sprite diamond;
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        float rand = Random.Range(0f, 1f);
        if (rand <.2f) {
            mySprite.sprite = stone;
        }
        else if (rand <.4f) {
            mySprite.sprite = water;
        }
        else if (.999f < rand && rand < 1f) {
            mySprite.sprite = diamond;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
