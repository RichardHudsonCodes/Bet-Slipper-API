import { Form } from "reactstrap"
import React, { useState } from "react"

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

   return(
    <div>
    <Form>
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
               <button onClick={() => removeRow(index)}>Remove</button>
            </div>)
            }
       )}
   </Form>
    <button onClick={addRow}>Add Row</button>
    </div>
   )
}