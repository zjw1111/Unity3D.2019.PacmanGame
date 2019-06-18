using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float speed;
    private int count;
    public int EachTime;
    public static int time;
    public Text countText;
    public Text winText;
    public Text levelText;
    public Text timeText;
    public static int level;
    private int[] levelScore = { 0, 14, 37, 41, 26, 20 };
    public static bool alreadyLoss;
    private bool alreadyWin;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        count = 0;
        time = EachTime;
        alreadyWin = alreadyLoss = false;
        int.TryParse(rb2D.gameObject.tag, out level);
        timeText.text = "Time: " + time.ToString();
        levelText.text = "Level: " + level;
        winText.text = "";
        setCountText();
        InvokeRepeating("TimeOut", 1, 1);
    }

    private void FixedUpdate()
    {
        if (alreadyLoss) return;
        if (time <= 0)
        {
            winText.text = "You Loss!";
            Invoke("ShowLossPage", 2);
            alreadyLoss = true;
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical= Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2D.AddForce(movement * speed);
        // Debug.Log("wasd: h: " + moveHorizontal + "v: " + moveVertical);
        // Debug.Log("position: h: " + transform.position.x + "v: " + transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!alreadyWin && !alreadyLoss && other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!alreadyWin && !alreadyLoss && other.gameObject.CompareTag("Zidan"))
        {
            winText.text = "You Loss!";
            Invoke("ShowLossPage", 2);
            alreadyLoss = true;
        }
    }

    void setCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count >= levelScore[level])
        {
            Debug.Log(count + " " + level);
            alreadyWin = true;
            winText.text = "You win!";
            Invoke("ShowWinText", 1);
        }
    }

    void ShowWinText()
    {
        if (level != levelScore.Length - 1)
        {
            winText.text = "You win!\nGo to Next Level...";
            Invoke("ShowNextLevel", 1);
        }
        else
        {
            Debug.Log("Win Page");
            SceneManager.LoadScene("Win");
        }
    }
    void ShowNextLevel()
    {
        Debug.Log("Next Level");
        level++;
        SceneManager.LoadScene("Level " + level.ToString());
    }
    void ShowLossPage()
    {
        Debug.Log("Loss Page");
        SceneManager.LoadScene("Loss");
    }
    void TimeOut()
    {
        if (time > 0 && !alreadyWin && !alreadyLoss)
        {
            time--;
            timeText.text = "Time: " + time.ToString();
        }
        else if (time <= 0) alreadyLoss = true;
    }
}
