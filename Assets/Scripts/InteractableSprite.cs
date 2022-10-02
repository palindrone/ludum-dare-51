using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableSprite : MonoBehaviour, IPointerClickHandler
{
    private bool _wasClicked;
    private List<IInteractable> _interactables = new List<IInteractable>();

    private void Awake()
    {
        var interactables =GetComponents<IInteractable>();
        foreach (var interactable in interactables)
        {
            RegisterInteractable(interactable);
        }
    }

    public void RegisterInteractable(IInteractable interactable)
    {
        _interactables.Add(interactable);
    }

    private void FixedUpdate()
    {
        if (_wasClicked)
        {
            _wasClicked = false;
            Interaction();
        }
    }

    void Interaction()
    {
        foreach (var interactable in _interactables)
        {
            interactable.Interact();
        }
    }

    /**
     * Temporary method to allow clicking objects that will be interactable later
     * 
     * NOTE: THIS ONLY WORKS ON GAMEOBJECTS WITH A COLLIDER
     */
    public void OnPointerClick(PointerEventData eventData)
    {
        _wasClicked = true;
    }
}
