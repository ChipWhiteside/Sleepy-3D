using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    public SpriteRenderer siblingSprite;
    private SpriteRenderer outlineSpriteRenderer;

    private void Start()
    {
        outlineSpriteRenderer = transform.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        outlineSpriteRenderer.sprite = siblingSprite.sprite;
        Debug.Log("MySRSprite: " + outlineSpriteRenderer.sprite);
        Debug.Log("SiblingSRSprite: " + siblingSprite.sprite);
    }
}
