import { React } from "react";
import Checkbox from "./CheckBox";




export default function SearchEngineList({ labels, selected, setSelected }) {
    function handleSelect(value, name) {  //https://www.codemzy.com/blog/react-select-all-checkbox
        if (value) {
            setSelected([...selected, name]);
        } else {
            setSelected(selected.filter((item) => item !== name));
        }
    };


    return (
        labels.length === 0 ? (
            <p>Loading...</p>
        ) : (
            
            <ul className="engines">
                {labels.map((label) => (
                    <li key={label.value} style={{ listStyle: 'none', marginBottom: '10px' }}>
                        <Checkbox key={label.value} name={label.name} value={selected.includes(label.name)} updateValue={handleSelect}>{label.name}</Checkbox>
                        
                    </li>
                ))}
            </ul>

        )
    )
}
