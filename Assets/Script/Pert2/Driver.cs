using UnityEngine;

public class Driver : MonoBehaviour
{
    //variabel pergerakan
    [SerializeField] private float steerSpeed = 200f; 
    [SerializeField] private float moveSpeed = 10f;
    
    // Variabel untuk efek ukuran
    [SerializeField] private float speed = 15f; 
    [SerializeField] private float scaleMin = 0.8f;
    [SerializeField] private float scaleMax = 1.2f;

    void Update()
    {
        // ambil input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        
        // untuk maju mundur
        transform.Translate(new Vector3(0f, verticalInput, 0f) * moveSpeed * Time.deltaTime);

        // di Rotate biar mobil berbelok
        transform.Rotate(new Vector3(0f, 0f, -horizontalInput) * steerSpeed * Time.deltaTime);

        // Panggil fungsi ubah ukuran
        UbahUkuran(verticalInput);
    }

    // Syarat 2: Method buatan sendiri untuk mengubah localScale
    void UbahUkuran(float gasInput)
    {
        // alasannya buat kasih efek visual ketika lagi gerak
        if (Mathf.Abs(gasInput) > 0.1f) 
        {
            // nyut nyut kalau jalan
            float t = (Mathf.Sin(Time.time * speed) + 1f) * 0.5f; 
            float scale = Mathf.Lerp(scaleMin, scaleMax, t); 
            transform.localScale = new Vector3(scale, scale, 1f);
        }
        else 
        {
            // belik normal kalau diem
            transform.localScale = new Vector3(scaleMin, scaleMin, 1f); 
        }
    }
}