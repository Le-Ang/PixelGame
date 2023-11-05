using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    [SerializeField] private Text cherriesText;

    //[SerializeField] private AudioSource collectionSoundEffect;

    private void Start()
    {
        cherriesText.text = "Cherries: " + ClassScore.getInstance().getScore();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Cherry"))
        {
            //collectionSoundEffect.Play();
            GameObject.FindGameObjectWithTag("SoundManager").
                GetComponent<SoundManager>().PlaySoundEffect(MusicEffect.COLLECT);
            Destroy(collision.gameObject);
            ClassScore.getInstance().scoreIncrease(1);
            Debug.Log("score   :  " + ClassScore.getInstance().getScore());
            cherriesText.text = "Cherries: " + ClassScore.getInstance().getScore();
            Debug.Log("This is my game path: " + Application.persistentDataPath);
        }    
    }
}
