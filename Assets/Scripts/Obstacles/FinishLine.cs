using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class FinishLine : MonoBehaviour
{
    public UnityEvent whoa;

    private void OnTriggerEnter(Collider other)
    {
        whoa?.Invoke();
        this.GetComponent<BoxCollider>().gameObject.SetActive(false);
    }
}