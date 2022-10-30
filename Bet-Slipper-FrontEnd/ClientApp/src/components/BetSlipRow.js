import { Button, Form } from "reactstrap"
import React, { useState } from "react"
import { Doubles } from "./Doubles";

export default function CreateRow (){

    const[inputFields, setInputFields] = useState([
       {
           bet:'', 
           market:'',
           actualOdds:'',
           minOdds:'',
           outcome:''
       }
   ])

   const [renderDoubles, setRenderDoubles] = useState(false); 

   const doubles = () =>  {
       setRenderDoubles(!renderDoubles); 
   }

   const handleFormChange = (index, event) => {
        let data = [...inputFields];
        data[index][event.target.name] = event.target.value;
        setInputFields(data);
   }
   
    const addRow = () => {
    let newfield = {bet:'', 
    market:'',
    actualOdds:'',
    minOdds:'' }
    setInputFields([...inputFields, newfield])
    }

    const removeRow = (index) => {
        let data = [...inputFields];
        data.splice(index, 1);
        setInputFields(data);
    }

    const submit = (e) => 
    {
        e.preventDefault();
        console.log(inputFields);
    }

    const DoublesTable = () => { 
       if (renderDoubles){ return <Doubles data = {inputFields.values} /> }
        else { return <div></div>}
     }

   return(
    <div>
    <Form onSubmit={submit}>
       {inputFields.map((input, index) => 
           { 
               return( 
               <div key={index}>
                   <input name="bet" 
                    placeholder="Bet" 
                    value={input.bet}
                    onChange={event => handleFormChange(index, event)}> 
                   </input>
                   <input name="market" 
                    placeholder="Market" 
                    value={input.market}
                    onChange={event => handleFormChange(index, event)}>
                   </input>
                   <input name="actualOdds" 
                    placeholder="Actual Odds" 
                    value={input.actualOdds}
                    onChange={event => handleFormChange(index, event)}>
                   </input>
                   <input name="minOdds" 
                    placeholder="Minimum Odds" 
                    value={input.minOdds}
                    onChange={event => handleFormChange(index, event)}>
                   </input>
               <Button onClick={() => removeRow(index)}>Remove</Button>   
            </div>)
            }
       )}
   </Form>
    <Button onClick={addRow}>Add Row</Button>
    <Button onClick={submit}>Submit</Button>
    <Button onClick={doubles}>Doubles</Button>
    <DoublesTable />
    </div>
   )
}