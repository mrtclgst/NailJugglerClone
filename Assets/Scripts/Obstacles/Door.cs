using System;
using UnityEngine;

public class Door : MonoBehaviour//isim degistir
{
    [SerializeField] OperationAction _action;
    [SerializeField] int _value;
    [SerializeField] GameObject side;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fingerR"))
        {
            Stack stackR;
            stackR = other.GetComponent<Stack>();
            int newTotalNails = ApplyMultiplyAction(_action, stackR.nails.Count, _value);
            stackR.ChangeNailCount(newTotalNails);
            gameObject.SetActive(false);
        }

        if (other.CompareTag("fingerL"))
        {
            Stack stackL;
            stackL = other.GetComponent<Stack>();
            int newTotalNails = ApplyMultiplyAction(_action, stackL.nails.Count, _value);
            stackL.ChangeNailCount(newTotalNails);
            gameObject.SetActive(false);
        }

        if (other.CompareTag("Nail"))
        {
            if (_action==OperationAction.Rainbow)
            {
                other.GetComponent<Nail>().ChangeColor();
            }
        }
    }
    int ApplyMultiplyAction(OperationAction action, int initial, int value)
    {
        switch (action)
        {
            case OperationAction.Add:
                return initial + value;
            case OperationAction.Minus:
                return initial - value;
            case OperationAction.Multiply:
                return initial * value;
            case OperationAction.Divide:
                return initial / value;
            case OperationAction.Rainbow:
                return initial;
            default:
                throw new ArgumentException();
        }
    }
}
