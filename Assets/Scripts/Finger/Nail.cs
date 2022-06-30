using UnityEngine;

public class Nail : MonoBehaviour
{
    [SerializeField] Gradient gradient;
    internal void ChangeColor()
    {
        GetComponent<Renderer>().material.color = gradient.Evaluate(Random.Range(0.5f, 1f));
    }
}
