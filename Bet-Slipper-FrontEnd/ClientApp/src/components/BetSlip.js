import React, { Component } from "react";
import CreateRow from "./BetSlipRow.js"


export class BetSlip extends Component 
{
    static displayName = BetSlip.name;
    render(){
        return(<CreateRow/>)
    } 
}