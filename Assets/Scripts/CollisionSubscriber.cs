using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
public abstract class CollisionSubscriber : MonoBehaviour
{
    private CollisionHandler _handler;

    

    protected abstract void ProcessCollision(IInteractable interactable);
}
