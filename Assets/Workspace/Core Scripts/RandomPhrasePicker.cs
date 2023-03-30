using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomPhrasePicker : MonoBehaviour
{
    private TMP_Text _textField;

    private void Awake()
    {
        _textField = GetComponent<TMP_Text>();
        _textField.text = Phrases.GetRandomPhrase();
    }
}