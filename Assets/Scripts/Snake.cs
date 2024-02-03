using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    private Vector2 direction;

    private List<Transform> segments;

    [SerializeField]
    private int intitalBody = 4;


    [SerializeField]
    private Transform segmentPrefab;

    private void Start() {
        direction = Vector2.right;
        segments = new List<Transform>();
        Time.timeScale = 0f;
        segments.Add(this.transform);
        for(int i=0; i<intitalBody; i++)
        {
            grow();
        }
    }

    void playerMovement()
    {
        if(Time.timeScale == 1f)
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
                if(direction != Vector2.down && direction != Vector2.up)
                {
                    direction = Vector2.up;
                    SoundManager.instance.playMoveUp();
                }
            }  else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
                if(direction != Vector2.up && direction != Vector2.down)
                {
                    direction = Vector2.down;
                    SoundManager.instance.playMoveDown();
                }
            }  else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
                if(direction != Vector2.right && direction != Vector2.left)
                {
                    direction = Vector2.left;
                    SoundManager.instance.playMoveLeft();
                }
            }  else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
                if(direction != Vector2.left && direction != Vector2.right)
                {
                    direction = Vector2.right;
                    SoundManager.instance.playMoveRight();
                }
            }
        }
    }

    private void Update() {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Time.timeScale = 1f;
        }
        playerMovement();
    }
    
    private void FixedUpdate() {
        if(Time.timeScale == 1)
        {
            for(int i=segments.Count -1; i>0; i-- )
            {
                segments[i].position = segments[i-1].position;
            }

            transform.position = new Vector3(
                Mathf.Round(transform.position.x + direction.x),
                Mathf.Round(transform.position.y + direction.y),
                0.0f);
        }
    }

    void grow()
    {
        Transform newSegment =  Instantiate(segmentPrefab);
        newSegment.position = segments[segments.Count - 1].position;
        segments.Add(newSegment);
    }

    void resetState()
    {
        for(int i=1; i<segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(this.transform);
        segments[0].position = Vector3.zero;
        for(int i=0; i<intitalBody; i++)
        {
            grow();
        }
        direction = Vector2.zero;
        Time.timeScale = 0f;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Food"))
        {
            SoundManager.instance.playbiteSound();
            grow();
        }
        if(other.CompareTag("Obstructions"))
        {
            SoundManager.instance.playGameOverSound();
            resetState();
            ScoreManager.instance.setScoretoZero();
            gameOver.isGameOver = true;
            // gameOver.instance.checkIfGameOver();
            // gameOver.instance.gameObject.SetActive(true);
            Debug.Log("isgamver = true1");
        }
    }
}
