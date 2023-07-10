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
    {//Wrapping:  메서드를 사용할때 내가 편하기 위해 재정의하거나 추가하는것을 랩핑이라고함.
     //빌드에 로그를 포함시키지 않는법 -> 전처리기의 이름 (디파인 심볼)
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

    //! GameObject 받아서 Text 컴포넌트 찾아서 text필드값 수정하는 함수

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

    //두백터를 더한다.

    public static Vector2 AddVector(this Vector3 origin, Vector2 addvector)
    {
        Vector2 result = new Vector2(origin.x, origin.y);
        result += addvector;
        return result;
    }
}
