using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dondurme : MonoBehaviour
{
    public float hiz;
    void Update()//sürekli döndüğü için update de
    {
        transform.Rotate(0, 0, hiz * Time.deltaTime);//dondurme de yer alan scripte girilen hız çarpımı ile döner.
    }
}
