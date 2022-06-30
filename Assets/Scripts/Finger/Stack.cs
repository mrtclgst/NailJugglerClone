using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using TMPro;

public class Stack : MonoBehaviour
{
    [SerializeField] Transform stackPoint;
    [SerializeField] Nail nailPrefab;
    [SerializeField] int initialNailCount = 3;
    [SerializeField] internal List<Nail> nails = new List<Nail>();
    [SerializeField] TextMeshPro nailText;
    private void Start()
    {
        AddNails(initialNailCount);
    }
    private void FixedUpdate()
    {
        nailText.text = nails.Count.ToString();
    }
    internal void ChangeNailCount(int newTotalNails)
    {
        int diff = newTotalNails - nails.Count;
        if (diff > 0)
        {
            AddNails(diff);
        }
        else if (diff < 0)
        {
            RemoveNails(diff);
        }
    }
    internal void AddNails(int diff)
    {
        for (int i = 0; i < diff; i++)
        {
            Nail go = Instantiate(nailPrefab, stackPoint.position, nailPrefab.transform.rotation, this.transform);
            stackPoint.transform.position += Vector3.up * 0.1f;
            nails.Add(go);
        }
    }
    internal void TransferNails(Nail item)
    {
        item.transform.position = stackPoint.transform.position;
        stackPoint.transform.position += Vector3.up * 0.1f;
    }
    internal void TransformNailFixer()
    {
        stackPoint.transform.position -= Vector3.up * 0.1f;
    }
    internal void RemoveNails(int diff)
    {
        while (diff < 0 && nails.Count > 0)
        {
            Destroy(nails[nails.Count - 1].gameObject);
            nails.RemoveAt(nails.Count - 1);
            stackPoint.transform.position -= Vector3.up * 0.1f;
            diff++;
        }
    }
}