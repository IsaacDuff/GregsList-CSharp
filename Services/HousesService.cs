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

    internal List<House> GetAll()
    {
        List<House> houses = _housesRepo.GetAll();
        return houses;
    }
}
