using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainImage : MonoBehaviour
{
    [SerializeField] private GameObject _image_Fundo;
    [SerializeField] private GameControler _gameController;

    public void OnMouseDown()
    {
        if(_image_Fundo.activeSelf && _gameController.canOpen)
        {
            _image_Fundo.SetActive(false);
            _gameController.imageOpened(this);
        }
    }
    private int _spriteId;
    public int spriteId
    {
        get { return _spriteId; }
    }

    public void ChangeSprite(int id,Sprite image)
    {
        _spriteId = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
    public void Close()
    {
        _image_Fundo.SetActive(true);
    }
}