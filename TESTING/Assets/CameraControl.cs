using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float disX = 0;
    private float disY = 0;

    public static bool teleporting;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init(transform);
    }

    // Update is called once per frame
    void Update()
    {
        disX = (transform.position.x - player.position.x);
        disY = transform.position.y - player.position.y;
        if (!DOTween.IsTweening(transform))
        {
            teleporting = false;
            if (Mathf.Abs(disX) > 9)
            {
                if (disX > 0)
                {
                    transform.DOMoveX(transform.position.x - 18, 0.5f);
                    teleporting = true;
                }
                else
                {
                    transform.DOMoveX(transform.position.x + 18, 0.5f);
                    teleporting = true;
                }
            }
            else if (Mathf.Abs(disY) > 5)
            {
                if (disY > 0)
                {
                    transform.DOMoveY(transform.position.y - 10, 0.5f);
                    teleporting = true;
                }
                else
                {
                    transform.DOMoveY(transform.position.y + 10, 0.5f);
                    teleporting = true;
                }
            }
        }
    }
}
