
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager uiManager;

    public virtual void Init(UIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    protected abstract MinigameState GetMiniGameState();
    public void SetActive(MinigameState state)
    {
        gameObject.SetActive(GetMiniGameState() == state);
    }
}
