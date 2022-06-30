using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brushes : MonoBehaviour
{
    [SerializeField] Material materialPhong;
    [SerializeField] ColorPicker phongColor;
    private void Start()
    {
        ChangeColorOfPhong(phongColor);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nail"))
        {
            other.GetComponent<Renderer>().material.color = materialPhong.color;
        }
    }
    private void ChangeColorOfPhong(ColorPicker phongColor)
    {
        switch (phongColor)
        {
            case ColorPicker.Red:
                materialPhong.color = Color.red;
                break;

            case ColorPicker.Green:
                materialPhong.color = Color.green;
                break;

            case ColorPicker.Yellow:
                materialPhong.color = Color.yellow;
                break;

            case ColorPicker.Blue:
                materialPhong.color = Color.blue;
                break;

            case ColorPicker.Black:
                materialPhong.color = Color.black;
                break;
        }
    }
}
public enum ColorPicker
{
    Red, Green, Yellow, Blue, Black
}
