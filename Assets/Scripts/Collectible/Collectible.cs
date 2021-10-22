using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectible : MonoBehaviour
{
    public enum CollectibleType
    {
        Dollar,
        Gold,
        Diamond
    }

    private Collider _objCollider;
    private List<GameObject> _collectibles;
    private Rigidbody _objRigidbody;

    [SerializeField]private bool isInPlayer = false;
    [SerializeField] private CollectibleType _type;
    [SerializeField] private GameObject _lastCollectible;
    [SerializeField] private float _collectibleMovementDuration;

    private void Awake()
    {
        _objCollider = GetComponent<Collider>();
        _objRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _collectibles = PlayerController.Instance.collectibles;
    }

    private void FixedUpdate()
    {
        if (isInPlayer)
        {
            //lerp

            transform.position = Vector3.Lerp(transform.position, _lastCollectible.transform.position, 10 * Time.fixedDeltaTime);

            transform.position = new Vector3(transform.position.x, transform.position.y,
                _lastCollectible.transform.position.z + 2.2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Player) && !isInPlayer)
        {
            _objCollider.isTrigger = false;
            Destroy(_objRigidbody);
            
            if (_collectibles.Count == 0)
            {
                _lastCollectible = PlayerController.Instance.gameObject;
                _collectibles.Add(gameObject);
            }
            else
            {
                _lastCollectible = _collectibles[_collectibles.Count - 1];
                _collectibles.Add(gameObject);
            }
            // StartCoroutine(MoveCollectibleToStack());
            isInPlayer = true;

        }

        if (other.CompareTag(Tags.Collectible) && !isInPlayer)
        {
            _objCollider.isTrigger = false;
            Destroy(_objRigidbody);

            _lastCollectible = _collectibles[_collectibles.Count - 1];
            _collectibles.Add(gameObject);
            // StartCoroutine(MoveCollectibleToStack());
            isInPlayer = true;

        }
    }

    private IEnumerator MoveCollectibleToStack()
    {
        float t = 0f;
        Vector3 startingPos = transform.position;
        while (t < _collectibleMovementDuration)
        {
            transform.position = Vector3.Lerp(startingPos, _lastCollectible.transform.position + Vector3.forward * 2.2f, t / _collectibleMovementDuration);
            t += Time.deltaTime;
            yield return null;
        }

        isInPlayer = true;
    }
}