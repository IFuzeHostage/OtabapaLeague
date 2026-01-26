using System;
using OtabapaLeague.Application.UI;
using OtabapaLeague.Application.UI.Elements;
using UnityEngine;

public class PlayerEditorView : View
{
    public event Action OnCancelButtonClicked;
    public event Action OnSubmitButtonClicked;
    public event Action OnAvatarButtonClicked;
    
    [SerializeField]
    private UITextInput _nameInput;
    [SerializeField] 
    private UITextInput _tagInput;
    [SerializeField]
    private TextButton _cancelButton;
    [SerializeField]
    private TextButton _submitButton;
    [SerializeField]
    private ImageButton _imageButton;
    
    public void SetNameText(string text)
    {
        _nameInput.Text = text;
    }

    public string GetNameText()
    {
        return _nameInput.Text;
    }
    
    public void SetTagText(string text)
    {
        _tagInput.Text = text;
    }
    
    public string GetTagText()
    {
        return _tagInput.Text;
    }

    public void SetCancelButtonText(string text)
    {
        _cancelButton.SetText(text);
    }
    
    public void SetSubmitButtonText(string text)
    {
        _submitButton.SetText(text);
    }

    public void SetAvatar(Sprite sprite)
    {
        _imageButton.SetImage(sprite);
    }
    
    protected override void InitComponents()
    {
        _cancelButton.OnClick += HandleCancelButtonClicked;
        _submitButton.OnClick += HandleSubmitButtonClicked;
        _imageButton.OnClick += HandleImageButtonClicked;
        
        base.InitComponents();
    }

    private void HandleSubmitButtonClicked()
    {
        OnSubmitButtonClicked?.Invoke();
    }
    
    private void HandleCancelButtonClicked()
    {
        OnCancelButtonClicked?.Invoke();
    }
    
    private void HandleImageButtonClicked()
    {
        OnAvatarButtonClicked?.Invoke();
    }
}
