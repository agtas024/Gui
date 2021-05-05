using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Yönetici : MonoBehaviour
{
    public Text leveltext,k1,k2,k3;
    public int kactop;
    GameObject Donen;
    GameObject Yarat;
    bool kontrol = true;
    public Animator animasyongecis;
    public Animator animasyon;//animatör tipinde animasyon değişkeni. pblicdir. animasyonun olduğu main kamera çekilerek yönetici objesinde yönetici scriptine atılır
    void Start()
    {
        PlayerPrefs.SetInt("kayit", int.Parse(SceneManager.GetActiveScene().name));
       leveltext.text = SceneManager.GetActiveScene().name;//sahne ismi text de yazacak
       Donen = GameObject.FindGameObjectWithTag("DonenCemberTag");//Donen=DonenCemberTag isimli taga sahip olan obje yani Donen_Cember
       Yarat = GameObject.FindGameObjectWithTag("yaratancemberTAG");//Yarat=yaratancemberTAG isimli taga sahip olan obje yani Yaratan_Cember
        yaratanlarıntexti();
    }
   public void yaratanlarıntexti()
    {
        if (kactop == 1)
        {
            k3.text = "";
           k2.text = "";
           k1.text = kactop + "";
        }
        else if (kactop == 2)
        {
            k3.text = "";
            k2.text = kactop - 1 + "";
            k1.text = kactop + "";
        }
        else if (kactop >= 3)
        {
            k3.text = kactop - 2 + "";
            k2.text = kactop - 1 + "";
            k1.text = kactop + "";
        }
        else if (kactop == 0)
        {
            k3.text = "";
            k2.text = "";
            k1.text = "";
                StartCoroutine(newlevel());
        }
    }
    public IEnumerator newlevel()
    {
        Donen.GetComponent<dondurme>().enabled = false; 
        Yarat.GetComponent<YaratanCember>().enabled = false;
        yield return new WaitForSeconds(1);
        if (kontrol)
        { 
          animasyongecis.SetTrigger("gecis");
          yield return new WaitForSeconds(2);
            if (int.Parse(SceneManager.GetActiveScene().name) == 12) {
                SceneManager.LoadScene("Ana Menü");
                PlayerPrefs.DeleteAll();
            }
          else SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1); //SceneManager.GetActiveScene() scene ismidir. integer yaptık. 1 ile topladık level arttı.
        }
        }
    public void oyun_bitti()
    {
            StartCoroutine(oyun_bitti_cagirdi());
    }
    public IEnumerator oyun_bitti_cagirdi()
    {
        kontrol = false;
        Donen.GetComponent<dondurme>().enabled = false; //Donen de bulunan objenin kodunun adı dondurme. o kodu disable et.
        Yarat.GetComponent<YaratanCember>().enabled = false; //Yarat da bulunan objenin kodunun adı YaratanCember. o kodu disable et.
        yield return new WaitForSeconds(1);
        animasyon.SetTrigger("oyunbitti");//oyunbitti.anim dosyasında kayıtlı olan animasyonu oynatır
        yield return new WaitForSeconds(2);//2 saniye bekle
        SceneManager.LoadScene("Ana Menü");//aa menü scene nine geçiş
    }
    }