import { React } from "react";
import Checkbox from "./CheckBox";

export default function SearchEngineList({ labels, register }) {  

    return (
        labels.length === 0 ? (
            <p>Loading... you may need to refresh the page once the backend has finished loading.</p>
        ) : (
             <>
                <p>Search engines:</p>
                <ul className="engines">
                    {labels.map((label) => (
                        <li key={label.value} style={{ listStyle: 'none', marginBottom: '10px' }}>
                            <Checkbox key={label.value} labelObj={label} register={register} />          
                        
                        </li>
                    ))}
                </ul>
            </>
        )
    )
}
