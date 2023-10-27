using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDoTween : MonoBehaviour
{
    private Rigidbody2D rid;

    private void Start()
    {
        rid = gameObject.GetComponent<Rigidbody2D>();
        JumpObj();
    }
    private void JumpObj()
    {
        rid.DOJump(new Vector2(3500f, 100f), 30f, 7, 5f,true);
        
    }
}
