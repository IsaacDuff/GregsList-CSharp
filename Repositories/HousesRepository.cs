using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gregslist_cSharp.Repositories;

public class HousesRepository
{

    private readonly IDbConnection _db;

    public HousesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal int CreateHouse(House houseData)
    {
        string sql = @"
        INSERT INTO houses(
            bathrooms, bedrooms, imgUrl, levels, price
        )
        values(
            @Bathrooms, @Bedrooms, @ImgUrl, @Levels, @Price
        );
        SELECT LAST_INSERT_ID();";

        int id = _db.ExecuteScalar<int>(sql, houseData);

        return id;
    }

    internal void EditHouse(House originalHouse)
    {
        string sql = @"
        UPDATE houses
        SET
        bathrooms = @Bathrooms,
        bedrooms = @Bedrooms,
        imgUrl = @ImgUrl,
        levels = @Levels,
        price = @Price
        ;";

        _db.Execute(sql, originalHouse);
    }

    internal List<House> GetAll()
    {
        string sql = "SELECT * FROM houses;";

        List<House> houses = _db.Query<House>(sql).ToList();
        return houses;
    }

    internal House GetOne(int houseId)
    {
        string sql = "SELECT * FROM houses WHERE id = @houseId;";

        House house = _db.Query<House>(sql, new { houseId }).FirstOrDefault();
        return house;
    }

    internal int Remove(int houseId)
    {
        string sql = "DELETE FROM houses WHERE id = @houseId LIMIT 1;";

        int rowsAffected = _db.Execute(sql, new { houseId });
        return rowsAffected;
    }
}
