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
    // YC3: Player có score < currentScore
    public void YC3(int currentScore)
    {
        Debug.Log("YC3 | Player có score thấp hơn:");

        foreach (var player in listPlayer.Where(p => p.Score < currentScore))
        {
            Debug.Log($"ID: {player.Id}, Name: {player.Name}, Score: {player.Score}");
        }
    }
    // YC4: Tìm player theo ID
    public void YC4(int currentId)
    {
        var player = listPlayer.FirstOrDefault(p => p.Id == currentId);

        if (player != null)
        {
            Debug.Log($"YC4 | ID: {player.Id}, Name: {player.Name}, Score: {player.Score}, Region: {player.Region.Name}");
        }
        else
        {
            Debug.Log("YC4 | Không tìm thấy player");
        }
    }
    // YC5: Sắp xếp score giảm dần
    public void YC5()
    {
        Debug.Log("YC5 | Danh sách theo score giảm dần:");

        foreach (var player in listPlayer.OrderByDescending(p => p.Score))
        {
            Debug.Log($"ID: {player.Id}, Name: {player.Name}, Score: {player.Score}");
        }
    }
    // YC6: 5 player score thấp nhất
    public void YC6()
    {
        Debug.Log("YC6 | Top 5 score thấp nhất:");

        foreach (var player in listPlayer.OrderBy(p => p.Score).Take(5))
        {
            Debug.Log($"ID: {player.Id}, Name: {player.Name}, Score: {player.Score}");
        }
    }
    // YC7: Tính điểm trung bình theo Region và lưu file
    public void YC7()
    {
        Debug.Log("YC7 | Điểm trung bình theo Region:");

        var result = listPlayer
            .GroupBy(p => p.Region.Name)
            .Select(g => new
            {
                Region = g.Key,
                AvgScore = g.Average(p => p.Score)
            });

        foreach (var item in result)
        {
            Debug.Log($"Region: {item.Region}, Avg Score: {item.AvgScore}");
        }
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