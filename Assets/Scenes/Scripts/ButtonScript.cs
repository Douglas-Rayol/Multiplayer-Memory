using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private GameControler gameController;
    [SerializeField] private string functionOnClick;


    public void OnMouseOver()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite != null)
        {
            sprite.color = Color.yellow;
        }
    }

    public void OnMouseDown()
    {
        transform.localScale = new Vector3(0.4f, 0.4f, 0.1f);
    }

    public void OnMouseUp()
    {
        transform.localScale = new Vector3(0.4f, 0.4f, 0.1f);
        if(gameController != null)
        {
            gameController.SendMessage(functionOnClick);
        }
    }

    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }


}
