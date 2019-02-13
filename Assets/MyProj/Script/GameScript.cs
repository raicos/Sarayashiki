using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {

    float time = 0;
    bool flag = true;
    public Text timer;
    public Text probText;

    int probCount = 0;
    int point = 0;

    GameObject DISH;

    Animator dish;

    AudioClip corretSE;
    AudioClip wrongSE;
    AudioSource dishAudio;

    List<string> probSentence = new List<string>()
    {
        "野球の人数","敬老の日がある月","1週間の日の数","「屋」の画数","車のタイヤの数",
        "春分の日がある月","秋分の日がある月","日本の都道府を足した数","日本の通貨の種類","バレーボールの人数",

        "サッカーの人数","ラグビーの人数","体育の日がある月","1年の月の数","文化の日がある月",
        "アメリカンフットボールの人数","勤労感謝の日がある月","電話のプッシュボタンの数","成人する年れい","小学校を卒業する年れい",


    };

    // true = たりない，false = たりる
    List<bool> probBool = new List<bool>()
    {
        true,true,true,true,true,true,true,true,true,true,
        false,false,false,false,false,false,false,false,false,false,
    };




    // Use this for initialization
    void Start() {
        time = 0;
        flag = true;
        DISH = GameObject.Find("DISH");
        dish = DISH.GetComponent<Animator>();
        
        corretSE = Resources.Load("Quiz-Correct_Answer02-1", typeof(AudioClip)) as AudioClip;
        wrongSE = Resources.Load("Quiz-Wrong_Buzzer02-1", typeof(AudioClip)) as AudioClip;
        dishAudio = DISH.GetComponent<AudioSource>();
        dishAudio.pitch = 0.45f;
    }

    // Update is called once per frame
    void Update() {
        if (!flag)
        {

            if(probCount >= 10)
            {
                flag = true;
                naichilab.RankingLoader.Instance.SendScoreAndShowRanking(100 - ((10-point)*10)-time);
            }
            else
            {
                time += Time.deltaTime;
            }

        }

        timer.text = time.ToString("00.00");

        if(dish.GetCurrentAnimatorStateInfo(0).IsName("dish_out"))
        {
            dish.SetBool("dish", false);
        }
    }

    public void changeFlag()
    {
        flag = !flag;
    }

    bool ans;
    public void nextProb()
    {
        int idx = Random.RandomRange(0, probSentence.Count);
        probText.text = probSentence[idx]+"は？";
        ans = probBool[idx];

        probSentence.RemoveAt(idx);
        probBool.RemoveAt(idx);
    }

    public void onTariru()
    {
        probCount += 1;
        
        if (!ans)
        {
            point += 1;
            dishAudio.PlayOneShot(corretSE);

        }
        else
        {
            dishAudio.PlayOneShot(wrongSE);
        }


        if(probCount < 10)
        {
            dish.SetBool("dish", true);
            nextProb();
        }
        
    }

    public void onTarinai()
    {
        probCount += 1;
        
        if (ans)
        {
            point += 1;
            dishAudio.PlayOneShot(corretSE);
        }
        else
        {
            dishAudio.PlayOneShot(wrongSE);
        }

        if (probCount < 10)
        {
            dish.SetBool("dish", true);
            nextProb();
        }

    }
}
