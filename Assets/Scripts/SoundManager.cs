using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioClip biteSound, gameOverSound, moveUp, moveDown, moveLeft, moveRight;

    private void Awake() {
        if(instance == null)
            instance = this;
    }

    public void playbiteSound(){
        AudioSource.PlayClipAtPoint(biteSound, transform.position);
    }

    public void playGameOverSound(){
        AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
    }

    public void playMoveUp(){
        AudioSource.PlayClipAtPoint(moveUp, transform.position);
    }
    
    public void playMoveDown(){
        AudioSource.PlayClipAtPoint(moveDown, transform.position);
    }

    public void playMoveLeft(){
        AudioSource.PlayClipAtPoint(moveLeft, transform.position);
    }

    public void playMoveRight(){
        AudioSource.PlayClipAtPoint(moveRight, transform.position);
    }
}
