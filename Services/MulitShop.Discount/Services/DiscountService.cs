using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services;

public class DiscountService : IDiscountService
{   
    private readonly DapperContext _dapperContext;
    public DiscountService(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
    {
        string query = "insert into Coupons (Code, Rate,IsActive,ValidDate) values (@code, @rate,@isActive,@validDate)";
        var parameters = new DynamicParameters();
        parameters.Add("@code", createCouponDto.Code);
        parameters.Add("@rate", createCouponDto.Rate);
        parameters.Add("@isActive", createCouponDto.IsActive);
        parameters.Add("@validDate", createCouponDto.ValidDate);

        using(var connection = _dapperContext.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }

    }

    public async Task DeleteCouponAsync(int couponId)
    {
        string query = "delete from Coupons where CouponId = @couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@couponId", couponId);

        using(var connection = _dapperContext.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultCouponDto>> GetAllCouponsAsync()
    {
        string query = "select * from Coupons";
        using(var connection = _dapperContext.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultCouponDto>(query);
            return values.ToList();
        }
    }

    public async Task<ResultCouponDto> GetCodeDetailByCodeAsync(string code)
    {
        string query = "select * from Coupons where Code = @code";
        var parameters = new DynamicParameters();
        parameters.Add("@code", code);
        using (var connection = _dapperContext.CreateConnection())
        {
            var values = await connection.QueryFirstOrDefaultAsync<ResultCouponDto>(query, parameters);
            return values;
        }
    }

    public async Task<ResultCouponDto> GetCouponByIdAsync(int couponId)
    {
        string query = "select * from Coupons where CouponId = @couponId";

        var parameters = new DynamicParameters();
        parameters.Add("@couponId", couponId);
        using (var connection = _dapperContext.CreateConnection())
        {
            var values = await connection.QueryFirstOrDefaultAsync<ResultCouponDto>(query, parameters);
            return values;
        }

    }

    public async Task<int> GetDiscountCouponCode()
    {

        string query = "select count(*) from Coupons";
        using (var connection = _dapperContext.CreateConnection())
        {
            var values = await connection.QueryFirstOrDefaultAsync<int>(query);
            return values;
        }
    }

    public int GetDiscountCouponCountRate(string code)
    {
        string query = "select Rate from Coupons where Code = @code";
        var parameters = new DynamicParameters();
        parameters.Add("@code", code);
        using (var connection = _dapperContext.CreateConnection())
        {
            var values =  connection.QueryFirstOrDefault<int>(query, parameters);
            return values;
        }
    }

    public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
    {
        string query = "update Coupons set Code = @code, Rate = @rate, IsActive = @isActive, ValidDate = @validDate where CouponId = @couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@code", updateCouponDto.Code);
        parameters.Add("@rate", updateCouponDto.Rate);
        parameters.Add("@isActive", updateCouponDto.IsActive);
        parameters.Add("@validDate", updateCouponDto.ValidDate);
        parameters.Add("@couponId", updateCouponDto.CouponId);
        using (var connection = _dapperContext.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters); 
        }    
    }
}