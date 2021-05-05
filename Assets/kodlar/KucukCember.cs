using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KucukCember : MonoBehaviour
{
    Rigidbody2D fizik;
    Boolean hareket_kontrol=false;
    GameObject yntc;
    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();
        yntc = GameObject.FindGameObjectWithTag("yöneticiTAG");//yöneticiTAG isimli taga sahip olan objeyi yntc değişkenine atadık.
    }
    void FixedUpdate()
    {
        if (!hareket_kontrol) 
        {
            fizik.MovePosition(fizik.position + Vector2.up * Time.deltaTime * 25); //iğnelerin ilerlemesini sağlar. up yukarı ilerlemeyi sağlar. down olursa aşağı ilerler.
        }
    }
    void OnTriggerEnter2D(Collider2D carpisma)
    {
            if (carpisma.tag == "DonenCemberTag")
            {
                transform.SetParent(carpisma.transform); //normalde iğne topa hangi uzay ekseninde değerse orada kalır. ama bu metod sayesinde uzay ekseni değil çembere hangi noktada temas ettiyse orda kalmasını sağlar. bu sayede iğneler çembere yapışık bir şekilde döner
                hareket_kontrol = true; // hareket true oldu. yani o anki iğne temas etti. if e girip iğne yukarı doğru ilerleyemez.
            }
            if (carpisma.tag == "kucukcemberTAG")
            {
                yntc.GetComponent<Yönetici>().oyun_bitti();//yntc de olan objenin Yönetici isimli scriptindeki oyun_bitti() metoduna gider. [iğneler birbirie temas ederse ama]
        }
    }
}