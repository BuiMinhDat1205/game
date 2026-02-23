using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System.Threading;

public class ASM_MN : Singleton<ASM_MN>
{
    public List<Region> listRegion = new List<Region>();
    public List<Players> listPlayer = new List<Players>();

    private void Start()
    {
        // YC00: Khởi tạo Region
        createRegion();

        // YC01: Thêm player
        YC1(1, "Honey", 200, 0);
        YC1(2, "Cherry", 150, 1);
        YC1(3, "Anna", 300, 2);
        YC1(4, "Jude", 100, 3);

        // YC02: In danh sách player + rank
        YC2();
    }

    // =========================
    // YC00 - CREATE REGION
    // =========================
    public void createRegion()
    {
        listRegion.Add(new Region(0, "VN"));
        listRegion.Add(new Region(1, "VN1"));
        listRegion.Add(new Region(2, "VN2"));
        listRegion.Add(new Region(3, "JS"));
        listRegion.Add(new Region(4, "VS"));
    }

    // =========================
    // YC00 - Calculate rank
    // =========================
    public string calculate_rank(int score)
    {
        if (score < 100) return "Hạng Đồng";
        else if (score < 300) return "Hạng Bạc";
        else if (score < 500) return "Hạng Vàng";
        else return "Kim Cương";
    }

    // =========================
    // YC01 - Thêm player
    // =========================
    public void YC1(int id, string name, int score, int regionID)
    {
        Region playerRegion = listRegion.FirstOrDefault(r => r.ID == regionID);

        if (playerRegion != null)
        {
            listPlayer.Add(new Players(id, name, score, playerRegion));
            Debug.Log($"YC01 | ID:{id}, Name:{name}, Score:{score}, Region:{playerRegion.Name}");
        }
        else
        {
            Debug.LogError($"Không tìm thấy Region với ID = {regionID}");
        }
    }

    // =========================
    // YC02 - Xuất danh sách player + rank
    // =========================
    public void YC2()
    {
        Debug.Log("YC02 | Danh sách người chơi:");
        foreach (var player in listPlayer)
        {
            string rank = calculate_rank(player.Score);
            Debug.Log($"ID:{player.Id}, Name:{player.Name}, Score:{player.Score}, Region:{player.Region.Name}, Rank:{rank}");
        }
    }
    public void YC3()
    {
        // sinh viên viết tiếp code ở đây
    }
    public void YC4()
    {
        // sinh viên viết tiếp code ở đây
    }
    public void YC5()
    {
        // sinh viên viết tiếp code ở đây
    }
    public void YC6()
    {
        // sinh viên viết tiếp code ở đây
    }
    public void YC7()
    {
        // sinh viên viết tiếp code ở đây
    }
    void CalculateAndSaveAverageScoreByRegion()
    {
        // sinh viên viết tiếp code ở đây
    }

}

[SerializeField]
public class Region
{
     public int ID;
    public string Name;

    public Region(int id, string name)
    {
        ID = id;
        Name = name;
    }
}

[SerializeField]
public class Players
{
     public int Id;
    public string Name;
    public int Score;
    public Region Region;

    public Players(int id, string name, int score, Region region)
    {
        Id = id;
        Name = name;
        Score = score;
        Region = region;
    }
    }