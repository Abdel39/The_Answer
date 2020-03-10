using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeImage : MonoBehaviour
{
    // Start is called before the first frame update
    public Image _imageTest;
    public Sprite _sprite1Life;
    public Sprite _sprite2Lives;
    public Sprite _sprite3Lives;
    
    public static Image _image;
    public static Sprite _sprite1;
    public static Sprite _sprite2;
    public static Sprite _sprite3;
    void Start()
    {
        _image = _imageTest;
        _sprite1 = _sprite1Life;
        _sprite2 = _sprite2Lives;
        _sprite3 = _sprite3Lives;

        _image.sprite = _sprite3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void UpdateHeartImage(int currentLife)
    {
        switch (currentLife)
        {
            case 0:
                Debug.Log("0 lp");
                
                break;
            case 1:
                Debug.Log("1 lp");
                _image.sprite = _sprite1;
                break;
            case 2:
                Debug.Log("2 lp");
                _image.sprite = _sprite2;
                break;
            case 3 :
                Debug.Log("3 lp");
                _image.sprite = _sprite3;
                break;
        }
    }
}
