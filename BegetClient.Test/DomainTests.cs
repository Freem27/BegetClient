
namespace TDV.BegetClient.Test;

[Collection("Enviroment collection")]
public class DomainTests
{
    private BegetClient _client;

    public DomainTests()
    {
        _client = Shared.GetClient();
    }

    [Fact]
    public async Task GetZonesTests()
    {
        var sut = await _client.Domain.GetZoneList();

        // Assert
        Assert.NotEmpty(sut);
        Assert.Contains(sut, s => s.IsIdn);
        Assert.Contains(sut, s => !s.IsIdn);
        Assert.Contains(sut, s => s.IsNational == null);
        Assert.Contains(sut, s => s.IsNational == true);
        Assert.Contains(sut, s => s.IsNational == false);

        var sutRu = sut.Single(s => s.Zone == "ru");
        Assert.Equal(1, sutRu.Id);
        Assert.False(sutRu.IsIdn);
        Assert.True(sutRu.IsNational);
        Assert.Equal(1, sutRu.MaxRegistrePeriodYears);
        Assert.Equal(1, sutRu.MinRegistrePeriodYears);
        Assert.True(sutRu.Price > 100);
        Assert.True(sutRu.PriceRenew > 200);
        Assert.True(sutRu.PriceIdn > 100);
        Assert.True(sutRu.PriceIdnRenew > 200);
    }
    
    [Fact]
    public async Task CheckDomainToRegister_domain_exists()
    {
        var sut = await _client.Domain.CheckDomainToRegister("wwww", 1);

        Assert.False(sut.MayBeRegistered);
        Assert.True(sut.InSystem);
    }


    [Fact]
    public async Task CheckDomainToRegister_domain_not_exists()
    {
        var sut = await _client.Domain.CheckDomainToRegister(Guid.NewGuid().ToString(), 1);

        Assert.True(sut.MayBeRegistered);
        Assert.False(sut.InSystem);
        Assert.True(sut.Price > 100);
    }

}
