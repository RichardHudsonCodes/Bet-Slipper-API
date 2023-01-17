using AutoFixture;
using Bet_Slipper_API;
using Bet_Slipper_API.Commands;
using Bet_Slipper_API.Contracts;
using FluentAssertions;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Bet_Slipper_API_Tests;

public class GenerateMultiplesCommandTest
{
    private GenerateMultiplesCommand _generateMultiplesCommand = new GenerateMultiplesCommand();
    private Fixture _fixture = new();

    public GenerateMultiplesCommandTest()
    {
    }

    [Fact]
    public void Execute_GenerateMultipleCommand()
    {
        //arrange
        var bettingTestData = CreateValidBetTestData();

        //action
        var result = _generateMultiplesCommand.Execute(bettingTestData, 2);
        //assert
        result.Should().HaveCount(3);
    }

    [Fact]
    public void Execute_GenerateMultipleCommand_WithTwoBetsThatHaveTheSameMarket()
    {
        //arrange
        var bettingTestData = CreateValidBetTestData().ToList();

        var betDescription = CreateBetDescription(country: string.Empty, competition: string.Empty, market: "Winner", selection: string.Empty);

        bettingTestData.Add(CreateBet(betDescription));
        bettingTestData.Add(CreateBet(betDescription));
        //action
        var result = _generateMultiplesCommand.Execute(bettingTestData, 2);
        //assert
        result.Should().HaveCount(10);
    }

    [Fact]
    public void Execute_GenerateMultipleCommand_WithTwoBetsThatHaveTheSameCountry()
    {
        //arrange
        var bettingTestData = CreateValidBetTestData().ToList();

        var betDescription = CreateBetDescription(country: "United Kingdom", competition: string.Empty, market: string.Empty, selection: string.Empty);

        bettingTestData.Add(CreateBet(betDescription));
        bettingTestData.Add(CreateBet(betDescription));
        //action
        var result = _generateMultiplesCommand.Execute(bettingTestData, 2);
        //assert
        result.Should().HaveCount(12);
    }

    [Fact]
    public void Execute_GenerateMultipleCommand_WithTwoBetsThatHaveTheSameCompetition()
    {
        //arrange
        var bettingTestData = CreateValidBetTestData().ToList();
        var betDescription = CreateBetDescription(country: string.Empty, competition: "Premier League", market: string.Empty, selection: string.Empty);

        bettingTestData.Add(CreateBet(betDescription));
        bettingTestData.Add(CreateBet(betDescription));

        //action
        var result = _generateMultiplesCommand.Execute(bettingTestData, 2);
        //assert
        result.Should().HaveCount(12);
    }

    [Fact]
    public void Execute_GenerateMultipleCommand_WithTwoBetsThatHaveTheSameSelection()
    {
        //arrange
        var bettingTestData = CreateValidBetTestData().ToList();

        var betDescription = CreateBetDescription(country: string.Empty, competition: string.Empty, market: string.Empty, selection: "Manchester City");

        bettingTestData.Add(CreateBet(betDescription));
        bettingTestData.Add(CreateBet(betDescription));

        //action
        var result = _generateMultiplesCommand.Execute(bettingTestData, 2);
        //assert
        result.Should().HaveCount(3);
    }

    private IEnumerable<Bet> CreateValidBetTestData()
    {
        _fixture.Register<ObjectId>(() => ObjectId.GenerateNewId());
        var bets = _fixture.Create<List<Bet>>();
        return bets;
    }   

    private Bet CreateBet(BetDescription betDescription) 
    {
        _fixture.Customize<Bet>(bettingTestData => bettingTestData.With(btd => btd.Description, betDescription));
        var bet = _fixture.Create<Bet>();         
        return bet;
    }

    private Bet CreateBet() 
    {
        var bet = _fixture.Create<Bet>();
        return bet;
    }

    private BetDescription CreateBetDescription(string country, string competition, string market, string selection)
    {
        if (!string.IsNullOrEmpty(country)) 
        {
            _fixture.Customize<BetDescription>(betDescription => betDescription
            .With(bd => bd.Country, country)); 
        }
        if (!string.IsNullOrEmpty(competition))
        {
            _fixture.Customize<BetDescription>(betDescription => betDescription
            .With(bd => bd.Competition, competition)); 
        }
        if (!string.IsNullOrEmpty(market))
        {
            _fixture.Customize<BetDescription>(betDescription => betDescription
            .With(bd => bd.Market, market));
        }
        if (!string.IsNullOrEmpty(selection)) {
            _fixture.Customize<BetDescription>(betDescription => betDescription
            .With(bd => bd.Selection, selection));
        }
        
        return _fixture.Create<BetDescription>();
    }
}
