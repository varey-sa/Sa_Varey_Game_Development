using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ATTACKER_TYPE
{
    CREEP_FOX,
    CREEP_LIZARD
}

public class CreepPool : MonoBehaviour {
    public float maxInstance;
    public float maxSpeed;

    public GameObject prefab;

    public Transform _startPosition;
    public Transform _endPosition;

    public Transform _freeParent;
    public Transform _busyParent;

    private List<GameObject> _lstBusy;
    private List<GameObject> _lstFree;
    private List<GameObject> _lstPending;

    private void Awake()
    {
        _lstBusy = new List<GameObject>();
        _lstFree = new List<GameObject>();
        _lstPending = new List<GameObject>();
    }
    // Use this for initialization

    public void InstantPoolObjects(GameObject _pref, ATTACKER_TYPE type, Vector3 _position)
    {
        GameObject poolObject = null;
        int index = -1;
        if (_lstFree.Count > 0)
        {
            for (int i = 0; i < _lstFree.Count; i++)
            {
                if (_lstFree[i].GetComponent<Attacker>()._type == type)
                    index = i;
            }
        }
        if (index != -1)
        {
            _lstFree[index].transform.SetParent(_busyParent);
            _lstFree[index].transform.position = _position;
            _lstFree[index].SetActive(true);
            _lstFree[index].GetComponent<Health>().setHealth(100);
            poolObject = _lstFree[index];
            _lstBusy.Add(_lstFree[index]);
            _lstFree.Remove(_lstFree[index]);

        }
        else if (index == -1 || _lstFree.Count == 0)
        {
            poolObject = Instantiate(_pref);
            poolObject.GetComponent<Attacker>()._type = type;
            poolObject.transform.SetParent(_busyParent);
            poolObject.transform.position = _position;
            _lstBusy.Add(poolObject);
        }
    }

    public void CheckRecycle()
    {
        for (int i = 0; i < _lstBusy.Count;i++)
        {
            //Check whether object is out of visible range
            if (_lstBusy[i].transform.position.x <= _endPosition.position.x || _lstBusy[i].GetComponent<Attacker>().getAttackerHealth() <= 0)
            {
                _lstBusy[i].GetComponent<Health>().DealDamage(100);

                _lstPending.Add(_lstBusy[i]);
                _lstBusy[i].transform.SetParent(_freeParent);
                _lstBusy[i].SetActive(false);
            }
            // if(_lstBusy[i].GetComponent<Attacker>().getAttackerHealth() <= 0)
            // {
            //     _lstBusy[i].GetComponent<Health>().DealDamage(100);

            //     _lstPending.Add(_lstBusy[i]);
            //     _lstBusy[i].transform.SetParent(_freeParent);
            //     _lstBusy[i].SetActive(false);
            // }

        }
        for (int i = 0; i < _lstPending.Count;i++)
        {
            _lstFree.Add(_lstPending[i]);
            _lstBusy.Remove(_lstPending[i]);
        }
        _lstPending.Clear();
    }

    // Update is called once per frame
    void Update () 
    {
        CheckRecycle();
    }
}
/*
public abstract class PoolObjectBehaviour
{
    public Vector3 _target;
    public abstract void Move();
}
*/