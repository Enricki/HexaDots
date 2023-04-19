using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    //[SerializeField] 
    //private float _scaleFactor = 2f;
    //[SerializeField]
    //private float _time = 0.2f;

    private Vector3 _startScale;


    private void Awake()
    {
        _startScale = transform.localScale;
    }

    public void Scale(float scale, float time)
    {
        transform.LeanScale(_startScale * scale, time).setEase(LeanTweenType.easeSpring);
    }
}