using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Data;
using Unity.VisualScripting;

public class Cosa : MonoBehaviour
{

    [SerializeField] private int numero;
    private int speed = 1;
    // Start is called before the first frame update
    void Awake()
    {
        DOTween.Init();
    }

    private struct Tuple
    {
        public bool near;
        public bool dirW;
        public bool dirA;
        public bool dirS;
        public bool dirD;
        // W, A, S, D
    };

    private Tuple Side(GameObject go)
    {
        Tuple res = new();
        res.dirW = false; res.dirA = false; res.dirS = false; res.dirD = false;

        GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
        foreach (GameObject wall in walls) {
            if (Mathf.Abs((go.transform.position.x - wall.transform.position.x)) < 1.5f && Mathf.Abs((go.transform.position.y - wall.transform.position.y)) < 1.5f)
            {
                res.near = true;
                if ((go.transform.position.x - wall.transform.position.x < 1.5f) && (go.transform.position.x - wall.transform.position.x > 0))
                {
                    res.dirA = true;
                }
                if ((go.transform.position.x - wall.transform.position.x > -1.5f) && (go.transform.position.x - wall.transform.position.x < 0))
                {
                    res.dirD = true;
                }
                if ((go.transform.position.y - wall.transform.position.y < 1.5f) && (go.transform.position.y - wall.transform.position.y > 0))
                {
                    res.dirS = true;
                }
                if ((go.transform.position.y - wall.transform.position.y > -1.5f) && (go.transform.position.y - wall.transform.position.y < 0))
                {
                    res.dirW = true;
                }
            }
        }
        Debug.Log(res.ToString());
        return res;
    }

    // Update is called once per frame
    void Update()
    {
        if (!DOTween.IsTweening(transform))
        {
            if (Input.GetKey(KeyCode.W) && !Side(gameObject).dirW)
            {
                transform.DOMove(transform.position + new Vector3(0, speed, 0), 0.2f).SetEase(Ease.Linear);
            }
            if (Input.GetKey(KeyCode.A) && !Side(gameObject).dirA)
            {
                transform.DOMove(transform.position + new Vector3(-speed, 0, 0), 0.2f).SetEase(Ease.Linear);
            }
            if (Input.GetKey(KeyCode.S) && !Side(gameObject).dirS)
            {
                transform.DOMove(transform.position + new Vector3(0, -speed, 0), 0.2f).SetEase(Ease.Linear);
            }
            if (Input.GetKey(KeyCode.D) && !Side(gameObject).dirD)
            {
                transform.DOMove(transform.position + new Vector3(speed, 0, 0), 0.2f).SetEase(Ease.Linear);
            }
        }
    }
}
