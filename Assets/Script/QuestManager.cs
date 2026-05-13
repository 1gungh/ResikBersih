using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int sampahTerkumpul = 0;
    public int targetSampah = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("KENA: " + other.name);

        if (other.CompareTag("trash"))
        {
            sampahTerkumpul++;

            Debug.Log("Sampah terkumpul: " + sampahTerkumpul);

            Destroy(other.gameObject);

            if (sampahTerkumpul >= targetSampah)
            {
                Debug.Log("QUEST SELESAI!");
            }
        }
    }
}