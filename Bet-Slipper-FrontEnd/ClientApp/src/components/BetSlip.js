import React, { Component, useState } from "react";
import { Form } from "reactstrap";
import CreateRow from "./BetSlipRow.js"


export class BetSlip extends Component 
{
    static displayName = BetSlip.name;
    render(){
        return(<CreateRow/>)
    } 
}