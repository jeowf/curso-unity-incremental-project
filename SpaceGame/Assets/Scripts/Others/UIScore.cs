using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    public Text text;

    // Update is called once per frame
    public void UpdateText(int pontuacao)
    {
        text.text = "Pontuação: " + pontuacao.ToString();
    }
}
