using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour
{
    [SerializeField] private CountPart[] _coutParts;
    [SerializeField] private Sprite[] _numSprites;

    public void Init()
    {
        foreach(var item in _coutParts)
        {
            item.Init(_numSprites);
        }
    }

    public void SetValue(int value)
    {
        Debug.Log("SetValue - " + value);

        foreach (var item in _coutParts)
        {
            item.SetValue(value);
        }
    }


    [System.Serializable]
    private class CountPart
    {
        [SerializeField] private int _size;
        [SerializeField] private Image _image;

        private Sprite[] _sprites;

        public void Init(Sprite[] sprites)
        {
            _sprites = sprites;
        }

        public void SetValue(int value)
        {
            int i = 0;

            if (value >= _size)
            {
                i = value / _size;
                
                while( i >= 10)
                {
                    i -= 10;
                }
            }
            _image.sprite = _sprites[i];

        }
    }
}
