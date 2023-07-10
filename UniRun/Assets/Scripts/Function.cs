using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.Rendering;

public static partial class Function
{
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {//Wrapping:  �޼��带 ����Ҷ� ���� ���ϱ� ���� �������ϰų� �߰��ϴ°��� �����̶����.
     //���忡 �α׸� ���Խ�Ű�� �ʴ¹� -> ��ó������ �̸� (������ �ɺ�)
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }

    //! GameObject �޾Ƽ� Text ������Ʈ ã�Ƽ� text�ʵ尪 �����ϴ� �Լ�

    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        if(textComponent ==null || textComponent == default) { return; }
        
        textComponent.text = text;
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    //�ι��͸� ���Ѵ�.

    public static Vector2 AddVector(this Vector3 origin, Vector2 addvector)
    {
        Vector2 result = new Vector2(origin.x, origin.y);
        result += addvector;
        return result;
    }
}
