using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoScript : MonoBehaviour
{
    // Variables
    int score = 0;

    int secretsFound = 0; // Oyuncunun bulduğu gizli itemlerin sayısı
    float scoreMultiplier = 1f;

    string playerName;

    // Start is called before the first frame update
    void Start()
    {
        //Oyuncunun ismi Zihni soyismi Koşucu olsun
        playerName = "Zihni Koşucu";

        //Oyuncunun 95 skor yaptığını varsayalım
        score = 70;

        //Ve 3 tane gizli item bulduğunu varsayalım
        secretsFound = 3;

        //3. METOD ÇIKTISI
        printNick(playerName);

        //Kullanıcının ham skoru
        Debug.Log("Bonuslardan önce skor : " + score);

        //2. METOD ÇIKTISI Gizli itemlerin sayısına göre scoreMultiplier atansın (Float döndürür)
        scoreMultiplier = scoreMultiplierCalculate(secretsFound);
        Debug.Log("2. METOD çıktısı :\n Gizli item bonus çarpanı! : " + scoreMultiplier + "x");

        //1. METOD ÇIKTISI scoreMultiplier değişkenini de kullanan bu metod leveli geçip geçmediğini bool döndürür.
        bool scorePass = scoreCheck(score);
        Debug.Log("1. METOD çıktısı :\n Level başarılı mı? (Skor*Skor çarpanı > 100): " + scorePass);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 1. Metod int kullanarak if else içerisinde, scoreMultiplier ile çarpılmış skorun 100 üzerinde olup olmadığına bakar bool değer döndürür
    bool scoreCheck(int score)
    {
        bool scoreCheckResult = (this.score * scoreMultiplier > 100) ? true : false;
        return scoreCheckResult;
    }

    // 2. Metod secretsFound değişkenine yani bulunan gizli itemlerin sayısına göre çarpan seçer ve buna göre skor çarpanını geri döndürür.
    float scoreMultiplierCalculate(int secretsFound)
    {
        switch (secretsFound)
        {
            case 1:
                return 1.2f;
            case 2:
                return 1.3f;
            case 3:
                return 1.5f;
            default:
                return scoreMultiplier;
        }
    }

    // 3. Metod İsim soyismi harf harf piramit şeklinde ekrana yazdırır.
    void printNick(string playerName)
    {
        int counter = 0;
        while (counter <= this.playerName.Length)
        {
            Debug.Log(playerName.Substring(0, counter));
            counter++;
        }
        Debug.Log("3. METOD çıktısı tamamamlandı.\n (Kullanıcı isminin harf harf yazdırılması)");

    }
}
