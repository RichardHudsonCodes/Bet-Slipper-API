import React, { Component } from "react";
import { Form } from "reactstrap";


export class BetSlip extends Component 
{
    static displayName = BetSlip.name;

    render(){
        return(<Form>
            <label>Bet
                <input></input>
            </label>
            <label>Market
                <input></input>
            </label>
            <label>Actual Odds
                <input></input>
            </label>
            <label>Minimum Odds
                <input></input>
            </label>
        </Form>)
    } 
}