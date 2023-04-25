using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gregslist_cSharp.Services;


public class HousesService
{


    private readonly HousesRepository _housesRepo;

    public HousesService(HousesRepository housesRepo)
    {
        _housesRepo = housesRepo;
    }

    internal House CreateHouse(House houseData)
    {
        int id = _housesRepo.CreateHouse(houseData);
        House house = this.GetOne(id);
        return house;
    }

    internal House EditHouse(House houseData, int houseId)
    {
        House originalHouse = this.GetOne(houseId);

        originalHouse.Bathrooms = houseData.Bathrooms ?? originalHouse.Bathrooms;
        originalHouse.Bedrooms = houseData.Bedrooms ?? originalHouse.Bedrooms;
        originalHouse.ImgUrl = houseData.ImgUrl ?? originalHouse.ImgUrl;
        originalHouse.Levels = houseData.Levels ?? originalHouse.Levels;
        originalHouse.Price = houseData.Price ?? originalHouse.Price;

        _housesRepo.EditHouse(originalHouse);
        return originalHouse;
    }

    internal List<House> GetAll()
    {
        List<House> houses = _housesRepo.GetAll();
        return houses;
    }

    internal House GetOne(int houseId)
    {
        House house = _housesRepo.GetOne(houseId);
        if (house == null)
        {
            throw new Exception($"No House Available at ID: {houseId}");
        }
        return house;
    }

    internal string Remove(int houseId)
    {
        House house = this.GetOne(houseId);
        int rowsAffected = _housesRepo.Remove(houseId);
        return $"House {house.Id} is sold!";
    }
}
