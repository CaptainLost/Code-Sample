using System.Text;
using UnityEngine;

public static class AgentNameGenerator
{
    private static readonly string[] m_names = new string[]
    {
        "Emily",
        "James",
        "Olivia",
        "Benjamin",
        "Amelia",
        "William",
        "Sophia",
        "Michael",
        "Isabella",
        "Daniel"
    };

    private static readonly string[] m_surnames = new string[]
    {
        "Smith",
        "Johnson",
        "Williams",
        "Brown",
        "Jones",
        "Miller",
        "Davis",
        "Wilson",
        "Anderson",
        "Thomas"
    };

    public static string GetRandomName()
    {
        int randomNameIndex = Random.Range(0, m_names.Length);
        int randomSurnameIndex = Random.Range(0, m_surnames.Length);

        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append(m_names[randomNameIndex]);
        stringBuilder.Append(' ');
        stringBuilder.Append(m_surnames[randomSurnameIndex]);

        return stringBuilder.ToString();
    }
}