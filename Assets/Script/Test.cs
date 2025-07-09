using UnityEngine;

public class Test : MonoBehaviour
{
    // script buat cari infoholder udh itu ksh int nya ke dia
    // udh itu abis level done script C kirim data time ke info holder
    // Infoholder check klo script nya lgi di main level udh itu maybe masukin ke JSON file ato langsung slap ke game nya


    public LevelTimer LevelTimer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelTimer.StopTimer();
    }
}
