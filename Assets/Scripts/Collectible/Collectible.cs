using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = System.Random;


public class Collectible : MonoBehaviour
{
    public enum CollectibleType
    {
        Dollar,
        Gold,
        Diamond
    }

    #region Public Fields

    public CollectibleType _type;
    public int _scoreFactor;
    public bool isInPlayer = false;
    public bool isLastCollectible = false;
    public GameObject _lastCollectible;

    #endregion

    #region Private Fields

    private Collider _objCollider;
    private List<GameObject> _collectibles;
    private Rigidbody _objRigidbody;

    #endregion

    #region Serialized Fields

    [SerializeField] private float _distanceBetweenCollectibles = 1.2f;
    [SerializeField] private List<Material> _typeMaterials;
    [SerializeField] private float _collectibleMovementDuration;

    #endregion


    #region Unity Methods

    private void Awake()
    {
        _objCollider = GetComponent<Collider>();
        _objRigidbody = GetComponent<Rigidbody>();
        _scoreFactor = 1;

        DOTween.Init();
    }

    private void Start()
    {
        _collectibles = PlayerController.Instance.collectibles;
    }

    private void FixedUpdate()
    {
        if (isInPlayer)
        {
            transform.position = Vector3.Lerp(transform.position, _lastCollectible.transform.position,
                10 * Time.fixedDeltaTime);

            transform.position = new Vector3(transform.position.x, transform.position.y,
                _lastCollectible.transform.position.z + _distanceBetweenCollectibles);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Collectible otherCollectible = other.GetComponent<Collectible>();
        
        if (other.CompareTag(Tags.Player) && !isInPlayer && !PlayerController.Instance.isInATM)
        {
            _objCollider.isTrigger = false;
            Destroy(_objRigidbody);

            if (_collectibles.Count == 0)
            {
                _lastCollectible = PlayerController.Instance.gameObject;
                _collectibles.Add(gameObject);
                isLastCollectible = true;
            }
            else
            {
                _lastCollectible = _collectibles[_collectibles.Count - 1];
                _lastCollectible.GetComponent<Collectible>().isLastCollectible = false;
                
                _collectibles.Add(gameObject);
                isLastCollectible = true;
            }


            isInPlayer = true;
        }

        
        if (other.CompareTag(Tags.Collectible) && !isInPlayer && otherCollectible.isInPlayer && !PlayerController.Instance.isInATM)
        {
            isLastCollectible = true;
            _objCollider.isTrigger = false;
            Destroy(_objRigidbody);

            _lastCollectible = _collectibles[_collectibles.Count - 1];
            _lastCollectible.GetComponent<Collectible>().isLastCollectible = false;
            _collectibles.Add(gameObject);


            isInPlayer = true;
            
        }

        if (other.CompareTag(Tags.Collectible) && !isInPlayer && !otherCollectible.isInPlayer )
        {
            
        }
    }

    #endregion

    #region Private Methods

    private void ChangeType(Collectible collectible, CollectibleType type)
    {
        MeshRenderer _collectibleRenderer = collectible.GetComponent<MeshRenderer>();

        collectible._type = type;

        switch (collectible._type)
        {
            case CollectibleType.Dollar:
                _scoreFactor = 1;
                _collectibleRenderer.material = collectible._typeMaterials[0];
                break;
            case CollectibleType.Gold:
                _scoreFactor = 2;
                _collectibleRenderer.material = collectible._typeMaterials[1];
                break;
            case CollectibleType.Diamond:
                _scoreFactor = 3;
                _collectibleRenderer.material = collectible._typeMaterials[2];
                break;
        }
    }

    private IEnumerator MoveCollectibleToStack()
    {
        float t = 0f;
        Vector3 startingPos = transform.position;
        while (t < _collectibleMovementDuration)
        {
            transform.position = Vector3.Lerp(startingPos,
                _lastCollectible.transform.position + Vector3.forward * _distanceBetweenCollectibles,
                t / _collectibleMovementDuration);
            t += Time.deltaTime;
            yield return null;
        }

        isInPlayer = true;
    }

    #endregion

    private void OnEnable()
    {
        EventManager.OnCollectibleUpgrade += ChangeType;
    }

    private void OnDisable()
    {
        EventManager.OnCollectibleUpgrade -= ChangeType;
    }
}