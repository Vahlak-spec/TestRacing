using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private float _speedValue;
    public bool IsHide => _isHide;

    private bool _isHide;
    private float _speed;
    private float _offset;

    public void Summon(Vector3 position, float _maxOffset)
    {
        _isHide = false;

        Debug.Log("Summon");

        transform.position = position;
        _offset = _maxOffset;

        _sprite.enabled = true;
        _collider.enabled = true;
    }
    public void Hide()
    {
        _isHide = true;
        _sprite.enabled = false;
        _collider.enabled = false;
    }
    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
    private void Update()
    {
        if (_isHide) return;

        transform.position = new Vector3(transform.position.x, transform.position.y - (_speed * Time.deltaTime * _speedValue), transform.position.z);

        if (transform.position.y < -_offset)
            Hide();
    }
}
