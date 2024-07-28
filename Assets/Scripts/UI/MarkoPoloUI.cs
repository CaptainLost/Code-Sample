using System.Text;
using TMPro;
using UnityEngine;

public class MarkoPoloUI : MonoBehaviour
{
    [SerializeField]
    private GameObject m_textBox;
    [SerializeField]
    private TextMeshProUGUI m_displayText;

    private bool m_isOpen;

    public void Open()
    {
        m_isOpen = true;

        m_textBox.SetActive(true);
    }

    public void Close()
    {
        m_isOpen = false;

        m_textBox.SetActive(false);
    }

    public void Switch()
    {
        if (m_isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    public void Run()
    {
        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 1; i <= 100; i++)
        {
            bool isDivisibleBy3 = (i % 3 == 0);
            bool isDivisibleBy5 = (i % 5 == 0);

            if (isDivisibleBy3 && isDivisibleBy5)
            {
                stringBuilder.AppendLine("MarkoPolo");
            }
            else if (isDivisibleBy3)
            {
                stringBuilder.AppendLine("Marko");
            }
            else if (isDivisibleBy5)
            {
                stringBuilder.AppendLine("Polo");
            }
            else
            {
                stringBuilder.AppendLine(i.ToString());
            }
        }

        m_displayText.text = stringBuilder.ToString();
    }
}
