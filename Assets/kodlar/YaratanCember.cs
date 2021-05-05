using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaratanCember : MonoBehaviour
{
    float zaman = 0;
    public float atış_zamanı; //girilen zaman kadar atışlar arası bekler
    public GameObject kucuk_cember;//iğnenin nesnesi yaratan cember objesinin ilgili scriptine sürüklenir.
    GameObject azaltma;
    void Start()
    {
        azaltma = GameObject.FindGameObjectWithTag("yöneticiTAG");
    }

    void Update()
    {
        if (Input.GetButton("Fire1")&&Time.time>zaman)//mağusun sol tuşuna basılırsa ve o anki zaman, zaman adlı değişkenden büyükse...
        {
            Instantiate(kucuk_cember, transform.position, transform.rotation);//yaratıcı cemberden iğneler doğar.
            zaman = Time.time+atış_zamanı;//zaman = istenen atış zamanı +o anki zaman. iki iğne arası zaman yani
            azaltma.GetComponent<Yönetici>().kactop--;
            azaltma.GetComponent<Yönetici>().yaratanlarıntexti();
        }
    }
}
