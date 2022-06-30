using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using DG;
using DG.Tweening;

public class FingerController : MonoBehaviour
{
    [SerializeField]
    Stack fingerR, fingerL;

    [SerializeField] TouchInput touchInput;
    [SerializeField] GameObject finish;
    public UnityEvent fingerDelivery;
    int index = 0;

    private void Update()
    {
        if (finish.activeInHierarchy)
            return;
        
        if (touchInput.SwipeRight)
        {
            StartCoroutine(SwipingRight());
        }
        if (touchInput.SwipeLeft)
        {
            StartCoroutine(SwipingLeft());
        }
    }
    IEnumerator SwipingRight()
    {
        if (fingerL.nails.Count > 0)
        {
            var item = fingerL.nails[fingerL.nails.Count - 1];
            fingerR.nails.Add(item);
            fingerL.nails.RemoveAt(fingerL.nails.Count - 1);
            fingerL.TransformNailFixer();
            fingerR.TransferNails(item);
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator SwipingLeft()
    {
        if (fingerR.nails.Count > 0)
        {
            var item = fingerR.nails[fingerR.nails.Count - 1];
            fingerL.nails.Add(item);
            fingerR.nails.RemoveAt(fingerR.nails.Count - 1);
            fingerR.TransformNailFixer();
            fingerL.TransferNails(item);
            yield return new WaitForSeconds(1);
        }
    }

    public void Coroutine()
    {
        StartCoroutine(Equalization());
    }

    IEnumerator Equalization()
    {
        float diff = Mathf.Round((fingerL.nails.Count - fingerR.nails.Count) / 2);       //+ left side has more         - right side has more 

        if (diff > 0)   //left to right
        {
            for (int i = 0; i < diff; i++)
            {
                var item = fingerL.nails[fingerL.nails.Count - 1];
                fingerR.nails.Add(item);
                fingerL.nails.RemoveAt(fingerL.nails.Count - 1);
                fingerL.TransformNailFixer();
                fingerR.TransferNails(item);
                yield return new WaitForSeconds(.25f);
            }
        }

        else if (diff < 0)  //right to left
        {
            for (int i = 0; i < Mathf.Abs(diff); i++)
            {
                var item = fingerR.nails[fingerR.nails.Count - 1];
                fingerL.nails.Add(item);
                fingerR.nails.RemoveAt(fingerR.nails.Count - 1);
                fingerR.TransformNailFixer();
                fingerL.TransferNails(item);
                yield return new WaitForSeconds(.25f);
            }
        }

        StartCoroutine(FingerDelivererCoroutine());
    }
    IEnumerator FingerDelivererCoroutine()
    {
        if (fingerR.nails.Count - index - 1 <= 0 || fingerL.nails.Count - index - 1 <= 0)
        {
            GameManager.GM.Score = fingerL.nails.Count + fingerR.nails.Count;
            GameManager.GM.UpdateScore();
            yield return new WaitForSeconds(2);
            GameManager.GM.GameOver();
        }

        else if (fingerR.nails.Count - index - 1 > 0 || fingerL.nails.Count - index - 1 > 0)
        {
            fingerDelivery?.Invoke();
            yield return new WaitForSeconds(2);
            fingerR.nails[fingerR.nails.Count - index - 1].transform.SetParent(null);
            fingerR.nails[fingerR.nails.Count - index - 1].transform.DOMove(new Vector3(-0.22f, 1.5f, 81.52f + index), 1f);
            fingerR.nails[fingerR.nails.Count - index - 1].transform.DORotate(Vector3.up * 180, 1f);

            fingerL.nails[fingerL.nails.Count - index - 1].transform.SetParent(null);
            fingerL.nails[fingerL.nails.Count - index - 1].transform.DOMove(new Vector3(-5f, 1.5f, 81.52f + index), 1f);
            fingerL.nails[fingerL.nails.Count - index - 1].transform.DORotate(-Vector3.up, 1f);

            StartCoroutine(FingerDelivererCoroutine());
        }
        index++;
    }
}