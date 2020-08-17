using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //点数を表示するテキスト
    private GameObject ScoreText;

    public int score = 0; // スコア変数

    // Use this for initialization
    void Start()
    {

        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のScoreTextオブジェクトを取得
        this.ScoreText = GameObject.Find("ScoreText");
    }

    //ボールが星か雲に当たった場合の衝突判定
    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.CompareTag("SmallStarTag"))
        {
            Debug.Log("小さい星に当たった! 5点");
            score = score + 5;
            ScoreText.GetComponent<Text>().text = "得点" + score;
        }
        if (col.gameObject.CompareTag("LargeStarTag"))
        {
            Debug.Log("大きい星に当たった!　20点");
            score = score + 20;
            ScoreText.GetComponent<Text>().text = "得点" + score;
        }
        if (col.gameObject.CompareTag("SmallCloudTag"))
        {
            Debug.Log("小さい雲に当たった!　30点");
            score = score + 30;
            ScoreText.GetComponent<Text>().text = "得点" + score;
        }
        if (col.gameObject.CompareTag("LargeCloudTag"))
        {
            Debug.Log("大きい雲に当たった! 50点");
            score = score + 50;
            ScoreText.GetComponent<Text>().text = "得点" + score;
        }
        //else
        //{
            //それ以外の処理
        //}
    }
    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "ゲーム オーバー";
        }

    }
}