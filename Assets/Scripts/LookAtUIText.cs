using TMPro;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtUIText : MonoBehaviour
{
    public TextMeshProUGUI mText;
    public InputManager mInputManagerRef;

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().OnObjectLookedAt.AddListener(OnPlayerLookedAtObject);
        mInputManagerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();
        mText.text = "";
    }

    public string GetCurrentDisplayKey(InputAction actionRef)
    {
        string path = actionRef.bindings[0].path;
        return path.Substring(path.IndexOf('/') + 1).ToUpper();
        
    }

    public void OnPlayerLookedAtObject(GameObject go)
    {
        if (go == null)
        {
            mText.text = "";
        }
        else
        {
            mText.text = $"[{GetCurrentDisplayKey(mInputManagerRef.mOnFootActions.Interact)}] to activate " + go.name;
        }
           
    }
}
