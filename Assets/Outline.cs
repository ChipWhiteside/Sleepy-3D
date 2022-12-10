using Silence;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    [SerializeField]
    private float lerpSpeed = 0.5f;
    private float targetAlpha = 0.0f;
    
    public SpriteRenderer outlineSpriteRenderer;
    private Nightmare parentNightmare;

    private void Start()
    {
        //outlineSpriteRenderer = transform.GetComponent<SpriteRenderer>();
        parentNightmare = transform.GetComponentInParent<Nightmare>();

        outlineSpriteRenderer.color = new Color(0, 0, 0, 0);
    }

    private void OnMouseOver()
    {
        // If selected item and hovered nightmare match classes, highlight white, else grey
        float dist = Vector3.Distance(PlayerController.instance.transform.position, transform.position);
        if (InventoryManager.instance.selectedItem.nightmareClass == parentNightmare.nightmareClass && (dist <= PlayerController.instance.range))
        {
            outlineSpriteRenderer.color = Color.white;
        }
        else
        {
            outlineSpriteRenderer.color = Color.grey;
        }
    }

    private void OnMouseExit()
    {
        outlineSpriteRenderer.color = new Color(0, 0, 0, 0);
    }
}
