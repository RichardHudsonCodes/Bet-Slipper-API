using AutoFixture;
using Bet_Slipper_API;
using Bet_Slipper_API.Commands;

namespace Bet_Slipper_API_Tests;

public class GenerateMultiplesCommandTest
{
    private GenerateMultiplesCommand _generateMultiplesCommand = new GenerateMultiplesCommand(); 

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
        result.
    }


    private Bet[] CreateValidBetTestData()
    {
        var fixture = new Fixture();
        var bets = fixture.Create<Bet[]>();
        return bets;
    }
}
