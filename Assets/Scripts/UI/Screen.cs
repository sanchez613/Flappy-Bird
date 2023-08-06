using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;
    [SerializeField] protected Button PlayButton;
    [SerializeField] protected Button AdditionalButton;

    private void OnEnable()
    {
        PlayButton.onClick.AddListener(OnPlayButtonClick);
        AdditionalButton.onClick.AddListener(OnAdditionalButtonClick);
    }

    private void OnDisable()
    {
        PlayButton.onClick.RemoveListener(OnPlayButtonClick);
        AdditionalButton.onClick.RemoveListener(OnAdditionalButtonClick);
    }

    protected abstract void OnPlayButtonClick();
    protected abstract void OnAdditionalButtonClick();

    public abstract void Open();
    public abstract void Close();
}
